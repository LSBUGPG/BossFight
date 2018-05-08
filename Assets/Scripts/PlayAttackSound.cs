using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAttackSound : MonoBehaviour {

	public AudioSource bossAttacking;

	public void PlaySound(){
		bossAttacking.Play ();
	}
}