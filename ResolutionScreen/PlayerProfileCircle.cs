using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileCircle : MonoBehaviour
{

	//public PLAYERPROFILE playerProfile;
	Text text;
	CircleSlider slider;
	IStatistics statistics;

	void Start()
	{
		statistics = GameObject.FindGameObjectWithTag("Statistics").GetComponent<Statistics>();
		text = GetComponentInChildren<Text>();
		slider = GetComponentInChildren<CircleSlider>();
		text.text = string.Format("{0}%", (int)(GetStatisticsFloat() * 100));
		slider.MaxValue = 1;
		slider.SliderValue = GetStatisticsFloat();
	}

	float GetStatisticsFloat()
	{
		DataPercentage player = statistics.CreatePlayerPercentageData();

		float achieverScore = statistics.GetAchieverScore(player);
		float explorerScore = statistics.GetExplorerScore(player);
		float killerScore = statistics.GetKillerScore(player);
		float socializerScore = statistics.GetSocializerScore(player);

		return Mathf.Max(statistics.GetAchieverScore(player), statistics.GetExplorerScore(player), statistics.GetKillerScore(player), statistics.GetSocializerScore(player));
	}

	string GetStatisticsText(PLAYERPROFILE playerProfile)
	{
		DataPercentage player = statistics.CreatePlayerPercentageData();

		float achieverScore = statistics.GetAchieverScore(player);
		float explorerScore = statistics.GetExplorerScore(player);
		float killerScore = statistics.GetKillerScore(player);
		float socializerScore = statistics.GetSocializerScore(player);

		float highestScore = Mathf.Max(statistics.GetAchieverScore(player), statistics.GetExplorerScore(player), statistics.GetKillerScore(player), statistics.GetSocializerScore(player));

		if (highestScore == achieverScore)
			return string.Format("{0}%", (int)(achieverScore * 100));
		else if (highestScore == explorerScore)
			return string.Format("0%", (int)(explorerScore * 100));
		else if (highestScore == killerScore)
			return string.Format("0%", (int)(killerScore * 100));
		else if (highestScore == socializerScore)
			return string.Format("0%", (int)(socializerScore * 100));
		else
			return string.Format("Not enough data");
	}
}
public enum PLAYERPROFILE
{
	ACHIEVER,
	EXPLORER,
	KILLER,
	SOCIALIZER
};