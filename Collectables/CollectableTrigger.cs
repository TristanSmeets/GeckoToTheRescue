using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectableTrigger : MonoBehaviour
{
	Animator animator;

	private void Start()
	{
		PickUpEvent.Register(onPickup);
		animator = GetComponent<Animator>();
	}

	void onPickup(PickUpEvent pickUpEvent)
	{
		if (pickUpEvent.pickup.Type == PickUpType.PIZZA)
			animator.Play("CollectableFlyIn");
	}
}

