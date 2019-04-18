using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public struct DataPercentage
{
	float checkpointPercentage;
	float collectablePercentage;
	float enemiesKilledPercentage;
	float powerupPercentage;

	public DataPercentage(float checkpointPercentage, float collectablePercentage, float enemiesKilledPercentage, float powerupPercentage)
	{
		this.checkpointPercentage = checkpointPercentage;
		this.collectablePercentage = collectablePercentage;
		this.enemiesKilledPercentage = enemiesKilledPercentage;
		this.powerupPercentage = powerupPercentage;
	}

	public float CheckpointsPercentage { get { return checkpointPercentage; } }
	public float CollectablePercentage { get { return collectablePercentage; } }
	public float EnemiesKilledPercentage { get { return enemiesKilledPercentage; } }
	public float PowerupPercentage { get { return powerupPercentage; } }

	public DataPercentage Subtract(DataPercentage other)
	{
		checkpointPercentage -= other.CheckpointsPercentage;
		collectablePercentage -= other.CollectablePercentage;
		enemiesKilledPercentage -= other.EnemiesKilledPercentage;
		powerupPercentage -= other.PowerupPercentage;
		return this;
	}

	public static DataPercentage operator -(DataPercentage dataPercentage, DataPercentage other)
	{
		return dataPercentage.Subtract(other);
	}
}