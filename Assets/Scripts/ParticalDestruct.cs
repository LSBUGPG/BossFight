using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalDestruct : MonoBehaviour {


	float lifetime = 2;

	void Start () 
	{
		Destroy (gameObject, lifetime);
	}
}
