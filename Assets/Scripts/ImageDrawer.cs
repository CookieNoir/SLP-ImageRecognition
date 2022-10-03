using UnityEngine;
using UnityEngine.Events;

public class ImageDrawer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public UnityEvent<Texture2D> OnTextureDrawn;

    public void Draw(Texture2D texture)
    {
        if (texture)
        {
            Sprite sprite = Sprite.Create(texture,
                new Rect(0.0f, 0.0f, texture.width, texture.height),
                new Vector2(0.5f, 0.5f), Mathf.Max(texture.width, texture.height));
            _spriteRenderer.sprite = sprite;
            OnTextureDrawn.Invoke(texture);
        }
    }
}