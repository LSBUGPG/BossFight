using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Slider playerHP;
	public Slider bossHP;
	bool isDead = false;
	public GameObject player;
	public GameObject initials;

	void Update () 
	{
		if (playerHP.value <= 0 && isDead == false) 
		{
			Game_Over ();
		}
	}

	void Game_Over()
	{
		Debug.Log("GAME OVER");
		isDead = true;
		bool qualify = Leaderboard.DoIQualify ((int)bossHP.value);
		if (qualify) {
			initials.SetActive (true);
			Leaderboard.AddScore ("ASS", (int)bossHP.value);
		}
		DestroyGameObject ();
	}

	void DestroyGameObject()
	{
		Destroy (player);
	}
}
