using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubProfileCircle : MonoBehaviour {

	PLAYERPROFILE playerProfile;
	CircleSlider circleSlider;
	public Text percentage;
	public Text profile;
	float score;

	void Awake () {
		circleSlider = GetComponentInChildren<CircleSlider>();
		circleSlider.MaxValue = 1;
	}

	public void SetPlayerProfile(PLAYERPROFILE playerProfile)
	{
		profile.text = "" + playerProfile;
	}

	public void SetPercentage(float score)
	{
		percentage.text = string.Format("{0}%", (int)Mathf.Round(score * 100));
	}

	public void SetScore(float score)
	{
		circleSlider.SliderValue = score;
	}
}
