using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {
	
	[Header("Settings")]
	public float upstairsRayDistance=1.5f;
	public float rayMargin=0.5f;
	public int maxItemsUpstairs=3;
	public float explosionForce = 200;

	[Header("Effects")]
	public Animator animator;
	private int lastHit=-1;
	public GameObject effectStep1;
	public GameObject effectStep2;
	public GameObject explosion;

	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position+(Vector3.up*rayMargin), Vector3.up * upstairsRayDistance);
		RaycastHit2D[] hit = Physics2D.RaycastAll (transform.position+(Vector3.up*rayMargin),Vector3.up,upstairsRayDistance);

		if (lastHit != hit.Length) {
			lastHit = hit.Length;
			if(lastHit>=3)
				Explode (hit);
			else
				ApplyEffect (lastHit);
		}
	}

	private void Explode(RaycastHit2D[] hits){

		Instantiate (explosion, transform.position, transform.rotation);

		Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, upstairsRayDistance);
		foreach (Collider2D col in colliders) {
			Rigidbody2D targetRigidbody2D = col.gameObject.GetComponent<Rigidbody2D> ();
			if (targetRigidbody2D)
				targetRigidbody2D.AddForceAtPosition (new Vector2 (explosionForce, explosionForce), transform.position, ForceMode2D.Force);
		}

		gameObject.SetActive (false);
	}

	private void ApplyEffect(int effectNumber){
		effectStep1.SetActive (effectNumber == 1);
		effectStep2.SetActive (effectNumber == 2);
		animator.enabled = effectNumber != 0;
	}
}
