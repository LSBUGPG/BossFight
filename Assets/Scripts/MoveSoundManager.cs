using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSoundManager : MonoBehaviour {

	public AudioSource moveSound;

	void Start () {
		
	}
	

	void Update () {
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A)) {
			moveSound.Play();
		}
	}
}
