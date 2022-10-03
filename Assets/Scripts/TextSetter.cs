using UnityEngine;
using TMPro;

public class TextSetter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void SetText(string value)
    {
        _text.text = value;
    }
}