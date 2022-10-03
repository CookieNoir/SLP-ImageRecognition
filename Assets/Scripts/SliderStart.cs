using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderStart : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField, Range(0f, 1f)] private float _startValue;

    private void Start()
    {
        _slider.value = _startValue;
    }
}