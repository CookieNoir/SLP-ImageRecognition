using UnityEngine;
using UnityEngine.Events;

public class TextureResizer : MonoBehaviour
{
    [SerializeField] private FilterMode _resizedTextureFilterMode;

    public Texture2D ResizeTexture(Texture2D texture, Vector2Int size)
    {
        return Resize(texture, size.x, size.y, false, _resizedTextureFilterMode);
    }

    public static Texture2D Resize(Texture2D texture2D, int targetX, int targetY, bool mipmap = true, FilterMode filter = FilterMode.Bilinear)
    {
        RenderTexture rt = RenderTexture.GetTemporary(targetX, targetY, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
        RenderTexture.active = rt;
        Graphics.Blit(texture2D, rt);

        Texture2D newTexture = new Texture2D(targetX, targetY, TextureFormat.RGBA32, false);
        newTexture.filterMode = filter;

        newTexture.ReadPixels(new Rect(0.0f, 0.0f, targetX, targetY), 0, 0);
        newTexture.Apply();

        RenderTexture.ReleaseTemporary(rt);
        return newTexture;
    }
}