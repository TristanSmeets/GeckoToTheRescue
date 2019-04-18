using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomImage : MonoBehaviour {

	public Sprite[] HouseImages;
	Image image;

	// Use this for initialization
	void Start () {
		CheckpointReachedEvent.Register(onCheckpointReached);
		image = GetComponent<Image>();
	}

	void onCheckpointReached(CheckpointReachedEvent checkpointReachedEvent)
	{
		setRandomImage();
	}

	void setRandomImage()
	{
		int random = (int)Mathf.Round(Random.Range(0f, HouseImages.Length - 1));
		image.sprite = HouseImages[random];
	}
}
