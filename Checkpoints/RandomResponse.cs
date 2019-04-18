using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.IO;

public class RandomResponse : MonoBehaviour {

	Text uiText;
	public string[] Responses;

	void Start () {
		CheckpointReachedEvent.Register(onCheckpointReached);
		uiText = GetComponent<Text>();
	}

	void onCheckpointReached(CheckpointReachedEvent checkpointReachedEvent)
	{
		setRandomResponse();
	}

	void setRandomResponse()
	{
		int random = (int)Mathf.Round(Random.Range(0f, Responses.Length - 1));
		uiText.text = Responses[random];
	}
}
