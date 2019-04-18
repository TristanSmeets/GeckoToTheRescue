using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxTrigger : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		CheckpointReachedEvent.Register(onCheckpointReached);
		animator = GetComponent<Animator>();
	}

	void onCheckpointReached(CheckpointReachedEvent checkpointReachedEvent)
	{
		animator.Play("TextFadeIn");
	}
}
