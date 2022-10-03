using System;
using UnityEngine;
using TMPro;

public class WeightsButton : MonoBehaviour
{
    [SerializeField] private ButtonInteractionToggler _buttonToggler;
    [SerializeField] private TMP_Text _buttonText;
    public event Action<string> OnSpread;
    public event Action<int> OnClicked;
    private WeightMatrix _weightMatrix;
    private int _id;

    public void Initialize(int id, string name, WeightMatrix weightMatrix, Action<string> buttonAction, Action<int> buttonNotificationAction)
    {
        _id = id;
        _buttonText.text = name;
        _weightMatrix = weightMatrix;
        OnSpread += buttonAction;
        OnClicked += buttonNotificationAction;
    }

    public void BroadcastWeights()
    {
        OnSpread?.Invoke(_weightMatrix.ToString());
        OnClicked?.Invoke(_id);
    }

    public void ChangeInteractable(int clickedId)
    {
        _buttonToggler.ToggleInteraction(_id != clickedId);
    }
}