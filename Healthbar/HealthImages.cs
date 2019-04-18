using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthImages : MonoBehaviour
{

	public Sprite[] HealthIcons;
	Image image;
	Text livesText;
	int lives;
	int StartingImage;

	// Use this for initialization
	void Start()
	{
		StartingImage = HealthIcons.Length - 1;
		lives = GameObject.FindGameObjectWithTag("Statistics").GetComponent<StatisticsTracker>().Lives;
		image = GetComponent<Image>();
		image.sprite = HealthIcons[StartingImage];
		livesText = GetComponentInChildren<Text>();
		livesText.text = setLivesText(lives);
		PlayerDamagedEvent.Register(onDamageTaken);
		PlayerDeathEvent.Register(onPlayerDeath);
		PlayerRespawnEvent.Register(onPlayerRespawn);
	}

	void onPlayerRespawn(PlayerRespawnEvent playerRespawnEvent)
	{
		image.sprite = HealthIcons[HealthIcons.Length - 1];
	}

	void onDamageTaken(PlayerDamagedEvent playerDamagedEvent)
	{
		image.sprite = HealthIcons[(int)playerDamagedEvent.newHealth];
	}

	void onPlayerDeath(PlayerDeathEvent playerDeathEvent)
	{
		lives--;
		livesText.text = setLivesText(lives);
	}

	string setLivesText(int livesLeft)
	{
		return string.Format("X {0}", livesLeft);
	}
}
