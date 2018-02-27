//Goes on player damage hitbox
//Hi phil it's sem again

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAttackCode : MonoBehaviour {

	public Slider sliderUI;

	public GameObject boss;
	public BossScript1 bossScriptReference;
	public int bossHPReference;

    public bool doDamage = false;
    bool collidingWithBoss = false;

	void Start(){
		bossScriptReference = boss.GetComponent<BossScript1>();
	//	bossHPReference = bossScriptReference.HP;
	}

	public void OnTriggerEnter (Collider collider){

		if(collider.tag == "Boss"){
            //Debug.Log("damage enabled");
            collidingWithBoss = true;
		}
	}

    void Update()
    {
        if (doDamage && collidingWithBoss)
        {
            BossDamaged ();
            SliderFunction ();
        }
    }

	void OnTriggerExit (Collider collider){
		if (collider.tag == "Boss")
		{
            collidingWithBoss = false;
            //Debug.Log("damage disabled");
		}
		//collider.isTrigger = false;
	}

	public void BossDamaged (){
		print("Im hitting him");
		bossHPReference -= 5;
	}

	public void SliderFunction(){
		sliderUI.value = bossHPReference;
	}

}
