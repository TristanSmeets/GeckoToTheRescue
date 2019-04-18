using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSFX : MonoBehaviour {

	public AudioClip SoundEffect;
	[Range (0,1)]
	public float Volume;
	// Use this for initialization
	void Start () {
		CheckpointReachedEvent.Register(onCheckpointReached);
	}

	void onCheckpointReached(CheckpointReachedEvent checkpointReachedEvent)
	{
		EventQueue.Queue(new SoundEffectEvent(SoundEffect, Volume));
	}

	// Update is called once per frame
	void Update () {
		
	}
}
