using System;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
	AudioSource audioSource;

	void Start()
	{
		SoundEffectEvent.Register(onSoundEffect);
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.playOnAwake = false;
	}

	void onSoundEffect(SoundEffectEvent soundEffectEvent)
	{
		audioSource.PlayOneShot(soundEffectEvent.AudioClip, soundEffectEvent.Volume);
	}
}

