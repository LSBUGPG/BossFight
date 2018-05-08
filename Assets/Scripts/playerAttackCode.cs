//Goes on player damage hitbox
//Hi phil it's sem again

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAttackCode : MonoBehaviour {

	public Slider sliderUI;
	public AudioSource bossHit;
	public GameObject boss;
	public GameObject eye;
	public BossScript1 bossScriptReference;
	public int bossHPReference;
	public ParticleSystem hitEffect_boss;

	//public bool doDamage = true;
    public bool collidingWithBoss = false;

	void Start(){
		bossScriptReference = boss.GetComponent<BossScript1>();
	//	bossHPReference = bossScriptReference.HP;
	}

	public void OnTriggerEnter (Collider collider){

		if(collider.tag == "Boss"){
			Debug.LogFormat ("Colliding with {0}", name);
			BossDamaged ();
			SliderFunction ();
			Instantiate (hitEffect_boss.gameObject, eye.transform.position,Quaternion.identity);
            //Debug.Log("damage enabled");
            //collidingWithBoss = true;
		}
	}

    void Update()
    {
      /*  if (collidingWithBoss)
        {
            BossDamaged ();
            SliderFunction ();
        }*/
    }

	/*void OnTriggerExit (Collider collider){
		if (collider.tag == "Boss")
		{
            collidingWithBoss = false;
            //Debug.Log("damage disabled");
		}
		//collider.isTrigger = false;
	}*/

	public void BossDamaged (){
		print("Im hitting him");
		bossHPReference -= 5;
		bossHit.Play ();
	}

	public void SliderFunction(){
		sliderUI.value = bossHPReference;
	}

}