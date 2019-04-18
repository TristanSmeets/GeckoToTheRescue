using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScoreText : MonoBehaviour {

	Text highScoreText;
	IStatistics statistics;

	// Use this for initialization
	void Start () {
		statistics = GameObject.FindGameObjectWithTag("Statistics").GetComponent<Statistics>();
		highScoreText = GetComponent<Text>();
		highScoreText.text = string.Format("{0}",statistics.GetHighScore());
	}
}
