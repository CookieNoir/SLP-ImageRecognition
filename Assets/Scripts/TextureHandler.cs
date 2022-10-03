using UnityEngine;
using UnityEngine.Events;

public class TextureHandler : MonoBehaviour
{
    [SerializeField] private TextureResizer _textureResizer;
    public Vector2Int Size { get; private set; }
    public Texture2D ResizedTexture2D { get; private set; }
    public UnityEvent<Texture2D> OnTextureSet;
    public UnityEvent<Texture2D> OnResizedTextureSet;
    private Texture2D _texture2D;

    public void SetTexture(Texture texture)
    {
        _texture2D = (Texture2D)texture;
        OnTextureSet.Invoke(_texture2D);
        UpdateValues();
    }

    public void SetSize(Vector2Int size)
    {
        Size = size;
        UpdateValues();
    }

    public void UpdateValues()
    {
        if (_texture2D)
        {
            ResizedTexture2D = _textureResizer.ResizeTexture(_texture2D, Size);
            OnResizedTextureSet.Invoke(ResizedTexture2D);
        }
    }
}