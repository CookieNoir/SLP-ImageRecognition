
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractionToggler : MonoBehaviour
{
    [SerializeField] private Button _button;

    public void ToggleInteraction(bool value)
    {
        _button.interactable = value;
    }
}