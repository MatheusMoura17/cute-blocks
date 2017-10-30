using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour {

	public Transform spawnPoint;
	public GameObject shootPrefab;
	public float impulse=400;
	public float time=10;
	public bool byTime;

	void Start(){
		if (byTime)
			Invoke ("Shoot", time);
	}

	public void Shoot(){
		GameObject gm=Instantiate (shootPrefab, spawnPoint.position, Quaternion.identity);
		Vector2 direction = transform.up+Vector3.left*(Random.Range (-1.0f, 1.0f));
		gm.GetComponent<Rigidbody2D> ().AddForce (direction*impulse,ForceMode2D.Force);
		Invoke ("Shoot", time);
	}
}
