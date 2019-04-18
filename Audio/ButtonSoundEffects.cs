using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundEffects : MonoBehaviour {

	public AudioClip ClickClip;
	public AudioClip HoverClip;
	[RangeAttribute(0, 1)]
	public float Volume;

	public void PlayClickSound()
	{
		EventQueue.Queue(new SoundEffectEvent(ClickClip, Volume)); 
	}

	public void PlayHoverSound()
	{
		EventQueue.Queue(new SoundEffectEvent(HoverClip, Volume));
	}
}
