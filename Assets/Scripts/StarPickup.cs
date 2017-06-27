using UnityEngine;
using System.Collections;

public class StarPickup : MonoBehaviour {

	public GameObject pickupEffect;

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Block")) {
			GameObject.FindObjectOfType<ScoreManager>().AddScore();
			Instantiate (pickupEffect, transform.position, Quaternion.identity);
			AudioManager.PlaySound (GameSound.PICKUP);
			Destroy (gameObject);
		}
	}
}
