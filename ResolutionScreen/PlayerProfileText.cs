using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileText : MonoBehaviour
{

	Text playerProfileText;
	IStatistics statistics;

	// Use this for initialization
	void Start()
	{
		statistics = GameObject.FindGameObjectWithTag("Statistics").GetComponent<Statistics>();
		playerProfileText = GetComponent<Text>();
		playerProfileText.text = setPlayerProfile();
	}

	string setPlayerProfile()
	{
		string errorMessage = "Not Enough Data";
		DataPercentage player = statistics.CreatePlayerPercentageData();
		float highestProfile = Mathf.Max(statistics.GetAchieverScore(player), statistics.GetExplorerScore(player), statistics.GetKillerScore(player), statistics.GetSocializerScore(player));

		if (highestProfile == statistics.GetAchieverScore(player))
			return "Achiever";
		else if (highestProfile == statistics.GetExplorerScore(player))
			return "Explorer";
		else if (highestProfile == statistics.GetKillerScore(player))
			return "Killer";
		else if (highestProfile == statistics.GetSocializerScore(player))
			return "Socializer";

		return errorMessage;
	}
}
