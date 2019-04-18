using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundEffect : MonoBehaviour {

	public AudioClip audioClip;
	public AudioSource audioSource;
	public float Volume;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		EnemyDeathEvent.Register(onEnemyDeath);
	}

	void onEnemyDeath(EnemyDeathEvent enemyDeathEvent)
	{
		audioSource.PlayOneShot(audioClip);
	}
}
