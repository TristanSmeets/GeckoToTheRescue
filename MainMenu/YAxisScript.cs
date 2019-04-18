using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YAxisScript : MonoBehaviour {

	public float TrueValue;
	public float FalseValue;
	public string YAxis;
	Toggle toggle;

	private void Start()
	{
		toggle = GetComponent<Toggle>();
		toggle.isOn = false;
		PlayerPrefs.SetFloat(YAxis, FalseValue);
	}

	public void SetYAxisVariable()
	{
		switch (toggle.isOn)
		{
			case true:
				PlayerPrefs.SetFloat(YAxis, TrueValue);
				break;
			case false:
				PlayerPrefs.SetFloat(YAxis, FalseValue);
				break;
		}
	}
}
