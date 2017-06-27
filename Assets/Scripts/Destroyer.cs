using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	public float timeToDestroy = 1;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, timeToDestroy);
	}
}
