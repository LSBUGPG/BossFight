using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossAttackCode: MonoBehaviour {

	public Slider sliderUI;
	public bool attackOportunity;
	public GameObject player;
	public GameObject playerConnector;
	public Player playerScriptReference;
	public int playerHPReference;
	public float force = 10.0f;
	public ParticleSystem hitEffect_player;
	public AudioSource playerHit;

	void Start(){
		playerScriptReference = player.GetComponent<Player>();
	
	}

	public void OnTriggerEnter (Collider collider){

		if(collider.tag == "Player"){
			PlayerDamaged ();
			Player player = collider.GetComponent<Player> ();
			Instantiate (hitEffect_player.gameObject, playerConnector.transform.position,Quaternion.identity);
			//camera.Play ("ScreenShake");
			if (player != null) {
				Vector3 attackVector = collider.transform.position - transform.position;
				attackVector.y = 0.0f;
				player.KnockBack(attackVector.normalized * force);
			}
			SliderFunction ();
		}

	}

	void OnTriggerExit (Collider collider){
		//collider.isTrigger = false;
	}

	public void PlayerDamaged (){
		print("Im being hit");
		playerHPReference -= 10;
		playerHit.Play ();
	}
			
	public void SliderFunction(){
		sliderUI.value = playerHPReference;
	}

}
