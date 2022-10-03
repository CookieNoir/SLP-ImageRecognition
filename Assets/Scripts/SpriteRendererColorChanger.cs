using UnityEngine;

public class SpriteRendererColorChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void SetRedValue(float value)
    {
        Color color = _spriteRenderer.color;
        color.r = value;
        _spriteRenderer.color = color;
    }
}