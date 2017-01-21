using System;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class DebugVarData
{
	public string Label;
    public float MinValue, MaxValue, CurrentValue;

	[Serializable]
    public class InputEvent : UnityEvent<float> { }
    public InputEvent onInputChange = new InputEvent();
	private Slider.SliderEvent onkaka = new Slider.SliderEvent();
}

