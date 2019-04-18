using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerProfileScore : IComparable
{
	PLAYERPROFILE playerProfile;
	float score;

	public PlayerProfileScore(PLAYERPROFILE playerProfile, float score)
	{
		this.playerProfile = playerProfile;
		this.score = score;
	}

	public PLAYERPROFILE GetProfile()
	{
		return playerProfile;
	}

	public float GetScore()
	{
		return score;
	}

	#region IComparable implementation
	public int CompareTo(object otherScore)
	{
		PlayerProfileScore compareScore = otherScore as PlayerProfileScore;

		if (otherScore == null)
			return 1;
		else
			return score.CompareTo(compareScore.GetScore());
	}
	#endregion
}

