using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsTracker : MonoBehaviour
{
	StatsData tempStatsData;
	StatsData allStatsData;
	int respawnCounter;
	public int Lives;
	public GameObject ResolutionScreen;
	public string RespawnFadeObjectName;
	GameObject RespawnFadeObject;

	void Awake()
	{
		CheckpointReachedEvent.Register(OnCheckpointPassed);
		EnemyDeathEvent.Register(onEnemyKilled);
		GameOverEvent.Register(onGameOver);
		PickUpEvent.Register(onPickup);
		PlayerDamagedEvent.Register(onPlayerDamaged);
		PlayerDeathEvent.Register(onPlayerDeath);
		GameStartEvent.Register(onGameStart);
		respawnCounter = Lives;
		RespawnFadeObject = GameObject.Find(RespawnFadeObjectName);
	}

	void OnCheckpointPassed(CheckpointReachedEvent checkpointReachedEvent)
	{
		allStatsData += tempStatsData;
		tempStatsData.Reset();
		tempStatsData.CheckpointsPassed++;
	}
	void onEnemyKilled(EnemyDeathEvent enemyDeathEvent)
	{
		tempStatsData.EnemiesKilled++;
		print ("KILLED ENEMY TRACKED");
	}
	void onGameStart(GameStartEvent gameStartEvent)
	{
		allStatsData.TotalCheckpoints = gameStartEvent.AmountOfCheckpoints;
		allStatsData.TotalCollectables = gameStartEvent.AmountOfCollectables;
		allStatsData.TotalEnemies = gameStartEvent.AmountOfEnemies;
		allStatsData.TotalPowerups = gameStartEvent.AmountOfPowerups;
		print ("REGISTERED STATS ON GAME START");
	}
	void onGameOver(GameOverEvent gameOverEvent)
	{
		allStatsData.IsCompleted = gameOverEvent.IsCompleted;
		allStatsData += tempStatsData;
		Instantiate(ResolutionScreen);
	}
	void onPickup(PickUpEvent pickUpEvent)
	{
		if (pickUpEvent.pickup.Type == PickUpType.AMMO ||
			pickUpEvent.pickup.Type == PickUpType.SHIELD)
			tempStatsData.PowerupsCollected++;

		if (pickUpEvent.pickup.Type == PickUpType.PIZZA)
			tempStatsData.CollectablesGathered++;
	}
	void onPlayerDamaged(PlayerDamagedEvent playerDamagedEvent)
	{
		tempStatsData.DamageTaken++;
	}
	void onPlayerDeath(PlayerDeathEvent playerDeathEvent)
	{
		respawnCounter--;
		if (respawnCounter > 0)
			resetVariables();
		if (respawnCounter < 1)
		{
			RespawnFadeObject.SetActive(false);
			allStatsData += tempStatsData;
			EventQueue.Queue(new GameOverEvent(false));
			respawnCounter = Lives;
		}
	}
	void resetVariables()
	{
		tempStatsData.Reset();
	}
	public StatsData GetStats()
	{
		return allStatsData;
	}
}
