using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickBlast : MonoBehaviour {

	public float normalGravity=1;
	public float stickedGravity=0.01f;

	void OnTriggerEnter2D(Collider2D col){
		Rigidbody2D rigidbody2d = col.GetComponent<Rigidbody2D> ();
		if (rigidbody2d) {
			rigidbody2d.gravityScale = stickedGravity;
			rigidbody2d.velocity = Vector2.Max(rigidbody2d.velocity.normalized,new Vector2(stickedGravity,stickedGravity));
		}
	}

	void OnTriggerExit2D(Collider2D col){
		Rigidbody2D rigidbody2d = col.GetComponent<Rigidbody2D> ();
		if (rigidbody2d)
			rigidbody2d.gravityScale = normalGravity;
	}
}
