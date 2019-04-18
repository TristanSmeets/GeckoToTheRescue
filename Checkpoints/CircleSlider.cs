using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleSlider : MonoBehaviour
{
	Image sliderImage;
	[Range (0,5f)]
	public float FillSpeed;

	float maxValue;
	float sliderValue;

	private void Start()
	{
		sliderImage = GetComponent<Image>();
		sliderImage.fillAmount = 0;
	}

	public float MaxValue { get { return maxValue; } set { maxValue = value; } }
	public float SliderValue { get { return sliderValue; } set { sliderValue = value; } }

	// Update is called once per frame
	void Update()
	{
		gradualSliderChange(sliderValue);
	}

	void sliderValueChange(float value)
	{
		float amount = (value / maxValue);
		sliderImage.fillAmount = amount;
	}

	void gradualSliderChange(float value)
	{
		float amount = (value / maxValue);

		if (sliderImage.fillAmount < amount)
			sliderImage.fillAmount += (amount - sliderImage.fillAmount) * FillSpeed * Time.deltaTime;
	}
}
