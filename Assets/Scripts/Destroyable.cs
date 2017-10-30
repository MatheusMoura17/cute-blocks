using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

	public float time=10;
	public bool byTime;

	void Start(){
		if (byTime)
			Invoke ("Destroy", time);
	}

	public void Destroy(){
		Destroy (gameObject);
	}
}
