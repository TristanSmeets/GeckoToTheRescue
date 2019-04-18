using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesTracker : MonoBehaviour
{
	CircleSlider slider;
	Text text;
	Statistics statistics;
	int collectablesGathered = 0;
	int totalCollectables;
	int collectablesCheckpoint;

	// Use this for initialization
	void Start()
	{
		GameStartEvent.Register(onGameStart);
		PickUpEvent.Register(onCollectableGathered);
		PlayerRespawnEvent.Register(onPlayerRespawn);

		statistics = GameObject.FindGameObjectWithTag("Statistics").GetComponent<Statistics>();

		slider = GetComponentInChildren<CircleSlider>();
		text = GetComponentInChildren<Text>();
	}

	void onPlayerRespawn(PlayerRespawnEvent playerRespawnEvent)
	{
		collectablesGathered = statistics.GetCollectablesGathered();
	}

	void onGameStart(GameStartEvent gameStartEvent)
	{
		totalCollectables = gameStartEvent.AmountOfCollectables;
		slider.MaxValue = gameStartEvent.AmountOfCollectables;
		setText(collectablesGathered);
	}

	void onCollectableGathered(PickUpEvent pickUpEvent)
	{
		print("Type: " + pickUpEvent.pickup.Type);
		if (pickUpEvent.pickup.Type == PickUpType.PIZZA)
		{
			collectablesGathered++;
			slider.SliderValue = collectablesGathered;
			setText(collectablesGathered);
		}
	}

	void setText(int collectablesGathered)
	{
		text.text = string.Format("{0}\t/\t{1}", collectablesGathered, totalCollectables);
	}
}
