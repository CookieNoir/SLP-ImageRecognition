using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using SimpleFileBrowser;

public class TextureLoader : MonoBehaviour
{
    public UnityEvent<Texture> OnTextureLoaded;

    private void Start()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png", ".tiff"));
    }

    public void OpenFileBrowser()
    {
        FileBrowser.ShowLoadDialog(_OnSuccess, _OnCancel, FileBrowser.PickMode.Files);
    }

    private void _OnSuccess(string[] paths)
    {
        if (paths.Length > 0)
        {
            Debug.Log($"Path is {paths[0]}");
            StartCoroutine(_GetTextureCoroutine(paths[0]));
        }
    }

    private void _OnCancel()
    {
        Debug.Log("File loading is cancelled");
    }

    private IEnumerator _GetTextureCoroutine(string path)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("file:///" + path);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Texture texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            texture.wrapMode = TextureWrapMode.Clamp;
            OnTextureLoaded.Invoke(texture);
        }
    }
}