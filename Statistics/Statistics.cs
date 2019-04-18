using System;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour, IStatistics
{
	StatisticsTracker tracker;
	DataPercentage achiever;
	DataPercentage explorer;
	DataPercentage killer;
	DataPercentage socializer;
	DataPercentage player;

	void Awake()
	{
		tracker = GetComponent<StatisticsTracker>();
		achiever = new DataPercentage(1, 1, 1, 1);
		explorer = new DataPercentage(0, 1, 0, 0.5f);
		killer = new DataPercentage(0, 0, 1, 0.5f);
		socializer = new DataPercentage(1, 0.5f, 0, 0);
	}

	DataPercentage createPlayerPercentages()
	{
		return new DataPercentage(getCheckpointPercentage(), getCollectablePercentage(), getEnemiesKilledPercentage(), getPowerupPercentage());
	}

	float getCheckpointPercentage()
	{
		StatsData statsData = tracker.GetStats();
		if (statsData.TotalCheckpoints > 0)
			return (float)statsData.CheckpointsPassed / (float)statsData.TotalCheckpoints;
		return 0;
	}

	float getCollectablePercentage()
	{
		StatsData statsData = tracker.GetStats();
		if (statsData.TotalCollectables > 0)
			return (float)statsData.CollectablesGathered / (float)statsData.TotalCollectables;
		return 0;
	}

	float getEnemiesKilledPercentage()
	{
		StatsData statsData = tracker.GetStats();
		if (statsData.TotalEnemies > 0)
			return (float)statsData.EnemiesKilled / (float)statsData.TotalEnemies;
		return 0;
	}

	float getPowerupPercentage()
	{
		StatsData statsData = tracker.GetStats();
		if (statsData.TotalPowerups > 0)
			return (float)statsData.PowerupsCollected / (float)statsData.TotalPowerups;
		return 0;
	}

	float getDeltaScore(DataPercentage dataPercentage, DataPercentage player)
	{
		float deltaCheckpoint = Mathf.Abs(dataPercentage.CheckpointsPercentage - player.CheckpointsPercentage);
		float deltaCollectable = Mathf.Abs(dataPercentage.CollectablePercentage - player.CollectablePercentage);
		float deltaEnemies = Mathf.Abs(dataPercentage.EnemiesKilledPercentage - player.EnemiesKilledPercentage);
		float deltaPowerup = Mathf.Abs(dataPercentage.PowerupPercentage - player.PowerupPercentage);
		float sumDelta = deltaCheckpoint + deltaCollectable + deltaEnemies + deltaPowerup;
		return (4 - sumDelta) / 4;
	}

	public float GetAchieverScore(DataPercentage player)
	{
		return getDeltaScore(achiever, player);
	}

	public int GetTotalCheckpoints()
	{
		return tracker.GetStats().TotalCheckpoints;
	}

	public int GetCheckpointsPassed()
	{
		return tracker.GetStats().CheckpointsPassed;
	}

	public int GetCollectablesGathered()
	{
		return tracker.GetStats().CollectablesGathered;
	}

	public int GetTotalCollectables()
	{
		return tracker.GetStats().TotalCollectables;
	}

	public int GetDamageTaken()
	{
		return tracker.GetStats().DamageTaken;
	}

	public int GetTotalEnemies()
	{
		return tracker.GetStats().TotalEnemies;
	}

	public int GetEnemiesKilled()
	{
		return tracker.GetStats().EnemiesKilled;
	}

	public float GetExplorerScore(DataPercentage player)
	{
		return getDeltaScore(explorer, player);
	}

	public int GetHighScore()
	{
		return tracker.GetStats().TotalScore;
	}

	public float GetKillerScore(DataPercentage player)
	{
		return getDeltaScore(killer, player);
	}

	public int GetTotalPowerups()
	{
		return tracker.GetStats().TotalPowerups;
	}

	public int GetPowerupsCollected()
	{
		return tracker.GetStats().PowerupsCollected;
	}

	public float GetSocializerScore(DataPercentage player)
	{
		return getDeltaScore(socializer, player);
	}

	public DataPercentage CreatePlayerPercentageData()
	{
		return new DataPercentage(getCheckpointPercentage(), getCollectablePercentage(), getEnemiesKilledPercentage(), getPowerupPercentage());
	}

	public bool GetIsCompleted()
	{
		return tracker.GetStats().IsCompleted;
	}
}
