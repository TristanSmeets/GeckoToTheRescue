using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointsTracker : MonoBehaviour {

	CircleSlider slider;
	Text text;
	Statistics statistics;
	int checkpointsPassed;
	int totalCheckpoints;

	void Start () {
		GameStartEvent.Register(onGameStart);
		CheckpointReachedEvent.Register(onCheckpointReached);
		statistics = GameObject.FindGameObjectWithTag("Statistics").GetComponent<Statistics>();

		slider = GetComponentInChildren<CircleSlider>();
		text = GetComponentInChildren<Text>();
	}

	void onGameStart(GameStartEvent gameStartEvent)
	{
		totalCheckpoints = gameStartEvent.AmountOfCheckpoints;
		slider.MaxValue = gameStartEvent.AmountOfCheckpoints;
		text.text = string.Format("{0}\t/\t{1}", checkpointsPassed, totalCheckpoints);
	}

	void onCheckpointReached(CheckpointReachedEvent checkpointReachedEvent)
	{
		checkpointsPassed = statistics.GetCheckpointsPassed() + 1;
		slider.SliderValue = checkpointsPassed;
		text.text = string.Format("{0}\t/\t{1}", checkpointsPassed, totalCheckpoints);
	}
}
