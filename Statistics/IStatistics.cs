using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface IStatistics
{
	DataPercentage CreatePlayerPercentageData();
	float GetAchieverScore(DataPercentage playerData);
	int GetCheckpointsPassed();
	int GetTotalCheckpoints();
	int GetCollectablesGathered();
	int GetTotalCollectables();
	int GetDamageTaken();
	int GetTotalEnemies();
	int GetEnemiesKilled();
	float GetExplorerScore(DataPercentage playerData);
	int GetHighScore();
	float GetKillerScore(DataPercentage playerData);
	float GetSocializerScore(DataPercentage playerData);
	int GetPowerupsCollected();
	int GetTotalPowerups();
	bool GetIsCompleted();
}
