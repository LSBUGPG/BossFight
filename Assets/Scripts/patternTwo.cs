﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patternTwo : MonoBehaviour, IAttack {

	public float rotationSpeed = 10;
	public Material[] telegraphColours;
	Renderer rend;

	void Start() {
		rend = GetComponentInChildren<Renderer> ();
		rend.enabled = true;
		rend.sharedMaterial = telegraphColours[0];
	}

	public IEnumerator Attack () {
		float rotation = 0.0f;
		rend.sharedMaterial = telegraphColours [1];
		yield return new WaitForSeconds (0.5f);

		while (rotation < 180.0f) {
			rend.sharedMaterial = telegraphColours [1];
			rotation += rotationSpeed * Time.deltaTime;
			transform.localRotation = Quaternion.Euler (0.0f, -rotation, 0.0f);
			yield return null;
			rend.sharedMaterial = telegraphColours [0];
		}

		transform.localRotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);

	}
}