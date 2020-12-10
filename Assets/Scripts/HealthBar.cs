using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;

	public void SetMaxHealth(double health)
	{
		slider.maxValue = (int)health;
		slider.value = (int)health;

		fill.color = gradient.Evaluate(1f);
	}

	public void SetHealth(double health)
	{
		slider.value = (int)health;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
