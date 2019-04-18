using System;
using System.Collections.Generic;
using UnityEngine;

public struct StatsData
{
	int checkpointsPassed;
	int collectablesGathered;
	int damageTaken;
	int enemiesKilled;
	int powerupsCollected;
	int totalCheckpoints;
	int totalCollectables;
	int totalPowerups;
	int totalEnemies;
	int totalScore;
	bool isCompleted;

	public StatsData(int checkpointsPassed, int collectablesGathered, int damageTaken, int enemiesKilled, int powerupsCollected,
		int totalCheckpoints, int totalCollectables, int totalPowerups, int totalEnemies, int totalScore, bool isCompleted)
	{
		this.checkpointsPassed = checkpointsPassed;
		this.collectablesGathered = collectablesGathered;
		this.damageTaken = damageTaken;
		this.enemiesKilled = enemiesKilled;
		this.powerupsCollected = powerupsCollected;
		this.totalCheckpoints = totalCheckpoints;
		this.totalCollectables = totalCollectables;
		this.totalPowerups = totalPowerups;
		this.totalEnemies = totalEnemies;
		this.totalScore = totalScore;
		this.isCompleted = isCompleted;
	}

	public bool IsCompleted { get { return isCompleted; } set { isCompleted = value; } } 
	public int CheckpointsPassed { get { return checkpointsPassed; } set { checkpointsPassed = value; } }
	public int CollectablesGathered { get { return collectablesGathered; } set { collectablesGathered = value; } }
	public int DamageTaken { get { return damageTaken; } set { damageTaken = value; } }
	public int EnemiesKilled { get { return enemiesKilled; } set { enemiesKilled = value; } }
	public int PowerupsCollected { get { return powerupsCollected; } set { powerupsCollected = value; } }
	public int TotalCheckpoints { get { return totalCheckpoints; } set { totalCheckpoints = value; } }
	public int TotalCollectables { get { return totalCollectables; } set { totalCollectables = value; } }
	public int TotalPowerups { get { return totalPowerups; } set { totalPowerups = value; } }
	public int TotalEnemies { get { return totalEnemies; } set { totalEnemies = value; } }
	public int TotalScore { get { return totalScore; } set { totalScore = value; } }

	public static StatsData operator +(StatsData oldStatsData, StatsData tempStatsData)
	{
		return oldStatsData.Add(tempStatsData);
	}

	public StatsData Add(StatsData other)
	{
		checkpointsPassed += other.CheckpointsPassed;
		collectablesGathered += other.CollectablesGathered;
		damageTaken += other.DamageTaken;
		enemiesKilled += other.EnemiesKilled;
		powerupsCollected += other.PowerupsCollected;
		totalCheckpoints += other.TotalCheckpoints;
		totalCollectables += other.TotalCollectables;
		totalPowerups += other.TotalPowerups;
		totalEnemies += other.TotalEnemies;
		totalScore += other.TotalScore;
		return this;
	}

	public void Reset()
	{
		checkpointsPassed = 0;
		collectablesGathered = 0;
		damageTaken = 0;
		enemiesKilled = 0;
		powerupsCollected = 0;
		totalCheckpoints = 0;
		totalCollectables = 0;
		totalPowerups = 0;
		totalEnemies = 0;
		totalScore = 0;
	}
}

