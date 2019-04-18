using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffects : MonoBehaviour
{
	public AudioClip EnvironmentSoundEffect;
	public AudioClip EnemySoundEffect;
	public AudioClip DeathAudioClip;
	public float Volume;
	// Use this for initialization
	void Start()
	{
		PlayerDeathEvent.Register(onPlayerDeath);
		PlayerDamagedEvent.Register(onPlayerDamaged);
	}

	void onPlayerDeath(PlayerDeathEvent playerDeathEvent)
	{
		EventQueue.Queue(new SoundEffectEvent(DeathAudioClip, Volume));
	}

	void onPlayerDamaged(PlayerDamagedEvent playerDamagedEvent)
	{
		if (playerDamagedEvent.damage == 1)
			EventQueue.Queue(new SoundEffectEvent(EnvironmentSoundEffect, Volume));
		else if (playerDamagedEvent.damage == 2)
			EventQueue.Queue(new SoundEffectEvent(EnemySoundEffect, Volume));
	}
}
