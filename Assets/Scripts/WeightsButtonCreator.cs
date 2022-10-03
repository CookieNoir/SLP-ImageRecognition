using System;
using UnityEngine;

public class WeightsButtonCreator : MonoBehaviour
{
    [SerializeField] private GameObject _weightsButtonPrefab; // Should contain WeightsButton component
    [SerializeField] private Transform _targetTransform;
    public event Action<int> OnButtonClicked;
    private WeightsButton _firstButton;

    public void CreateButtons(string[] buttonNames, WeightMatrix[] weightMatrices, Action<string> buttonAction)
    {
        if (buttonNames != null && buttonNames.Length == weightMatrices.Length)
        {
            for (int i = 0; i < buttonNames.Length; ++i)
            {
                GameObject newObject = Instantiate(_weightsButtonPrefab, _targetTransform);
                WeightsButton button = newObject.GetComponent<WeightsButton>();
                if (button)
                {
                    button.Initialize(i, buttonNames[i], weightMatrices[i], buttonAction, NotifyButtons);
                    OnButtonClicked += button.ChangeInteractable;
                    if (i == 0) _firstButton = button;
                }
            }
        }
    }

    public void BroadcastFirst()
    {
        if (_firstButton) _firstButton.BroadcastWeights();
    }

    public void NotifyButtons(int id)
    {
        OnButtonClicked?.Invoke(id);
    }
}