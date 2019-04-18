using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignCircles : MonoBehaviour
{
	SubProfileCircle[] profileCircles;
	List<PlayerProfileScore> profileScores;
	IStatistics statistics;
	DataPercentage player;

	void Start()
	{
		profileScores = new List<PlayerProfileScore>();
		statistics = GameObject.FindGameObjectWithTag("Statistics").GetComponent<Statistics>();
		player = statistics.CreatePlayerPercentageData();
		profileCircles = GetComponentsInChildren<SubProfileCircle>();
		fillProfileScores();
		profileScores.Sort();
		profileScores.Reverse();
		assignCircles();
	}

	void fillProfileScores()
	{
		profileScores.Add(new PlayerProfileScore(PLAYERPROFILE.ACHIEVER, statistics.GetAchieverScore(player)));
		profileScores.Add(new PlayerProfileScore(PLAYERPROFILE.EXPLORER, statistics.GetExplorerScore(player)));
		profileScores.Add(new PlayerProfileScore(PLAYERPROFILE.KILLER, statistics.GetKillerScore(player)));
		profileScores.Add(new PlayerProfileScore(PLAYERPROFILE.SOCIALIZER, statistics.GetSocializerScore(player)));
	}

	void assignCircles()
	{
		for (int index = 0; index < profileCircles.Length; index++)
		{
			profileCircles[index].SetPlayerProfile(profileScores[index].GetProfile());
			profileCircles[index].SetScore(profileScores[index].GetScore());
			profileCircles[index].SetPercentage(profileScores[index].GetScore());
		}
	}
}
