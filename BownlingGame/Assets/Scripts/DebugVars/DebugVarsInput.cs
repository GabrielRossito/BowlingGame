using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class DebugVarsInput : MonoBehaviour
{
    public float CurrentValue { get { return _slider.value; } }

    private Slider _slider { get { return GetComponentInChildren<Slider>(); } }
    private Text _label { get { return GetComponentsInChildren<Text>()[0]; } }
    private Text _value { get { return GetComponentsInChildren<Text>()[1]; } }

    // public class SliderEvent : UnityEvent<float> { }
    // public SliderEvent onValueChanged = new SliderEvent();

    private DebugVarData _data;

    public void Initialize(DebugVarData data)
    {
        name = _label.text =  data.Label;

        _data = data;

        _slider.minValue = data.MinValue;
        _slider.maxValue = data.MaxValue;
        // _slider.value = data.CurrentValue;
        ValueChanged(data.CurrentValue);
        _slider.value = data.CurrentValue;

        _slider.onValueChanged.AddListener(ValueChanged);
    }

    private void ValueChanged(float value)
    {
        _value.text = value.ToString("00");
        _data.CurrentValue = value;
        _data.onInputChange.Invoke(value);
    }
}
