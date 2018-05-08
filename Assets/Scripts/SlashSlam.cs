using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashSlam : MonoBehaviour, IAttack {

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
		dangerZone.sharedMaterial = telegraphColours [1];
		yield return new WaitForSeconds (0.5f);

		bossAttacks.Play ("Slash slam");

		dangerZone.sharedMaterial = telegraphColours [0];
		yield return new WaitForSeconds (1f);
	}
}