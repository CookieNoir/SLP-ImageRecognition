using UnityEngine;
using TMPro;

public class SizeShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void ShowSize(Texture2D texture)
    {
        if (texture)
        {
            _text.text = $"{texture.width}x{texture.height}";
        }
    }
}