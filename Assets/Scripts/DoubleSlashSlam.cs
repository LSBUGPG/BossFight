﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSlashSlam : MonoBehaviour, IAttack {

//	public float rotationSpeed = 10;
	public Material[] telegraphColours;
	public Transform boss;
	public Renderer dangerZone;
	public Animator bossAttacks;

	void Start() {
		dangerZone.enabled = true;
		dangerZone.sharedMaterial = telegraphColours[0];
		bossAttacks = GetComponentInChildren<Animator> ();
	}

	public IEnumerator Attack () {
	//	float rotation = 0.0f;
		dangerZone.sharedMaterial = telegraphColours [1];
		yield return new WaitForSeconds (0.5f);
		bossAttacks.Play ("Double slash slam");

		dangerZone.sharedMaterial = telegraphColours [0];
		yield return new WaitForSeconds (2.10f);
	}
}
