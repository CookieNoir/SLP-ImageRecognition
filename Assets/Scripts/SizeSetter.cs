using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SizeSetter : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputFieldX;
    [SerializeField] private TMP_InputField _inputFieldY;
    [SerializeField, Min(1)] private int _startXValue;
    [SerializeField, Min(1)] private int _startYValue;
    public UnityEvent<Vector2Int> OnSizeSet;

    private void Start()
    {
        _inputFieldX.text = _startXValue.ToString();
        _inputFieldY.text = _startYValue.ToString();
        _SetSize();
    }

    public void OnEndEdit(string value)
    {
        _SetSize();
    }

    private void _SetSize()
    {
        int x = Convert.ToInt32(_inputFieldX.text);
        int y = Convert.ToInt32(_inputFieldY.text);
        Vector2Int size = new Vector2Int(x, y);
        OnSizeSet.Invoke(size);
    }
}