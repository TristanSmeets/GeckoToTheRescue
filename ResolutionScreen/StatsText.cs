using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsText : MonoBehaviour {

	public STATISTIC StatisticType;
	Text statisticText;
	IStatistics statistics;

	void Start () {
		statistics = GameObject.FindGameObjectWithTag("Statistics").GetComponent<Statistics>();
		statisticText = GetComponent<Text>();
		statisticText.text = setStatisticText(StatisticType);
	}

	string setStatisticText(STATISTIC statistic)
	{
		switch (statistic)
		{
			case STATISTIC.CHECKPOINTS:
				return string.Format("{0}/{1}", statistics.GetCheckpointsPassed(), statistics.GetTotalCheckpoints());
			case STATISTIC.COLLECTABLES:
				return string.Format("{0}/{1}", statistics.GetCollectablesGathered(), statistics.GetTotalCollectables());
			case STATISTIC.DAMAGE:
				return string.Format("{0}", statistics.GetDamageTaken());
			case STATISTIC.KILLS:
				return string.Format("{0}/{1}", statistics.GetEnemiesKilled(), statistics.GetTotalEnemies());
			case STATISTIC.MESSAGES:
				return string.Format("{0}/{1}", statistics.GetPowerupsCollected(), statistics.GetTotalPowerups());
			default:
				return string.Format("Error: Not Implemented enum");
		}
	}
}

public enum STATISTIC
{
	CHECKPOINTS,
	COLLECTABLES,
	DAMAGE,
	KILLS,
	MESSAGES
};