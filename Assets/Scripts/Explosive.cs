using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {
	
	[Header("Settings")]
	public float upstairsRayDistance=1.5f;
	public float rayMargin=0.5f;
	public int maxItemsUpstairs=3;

	[Header("Effects")]
	public Animator animator;
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position+(Vector3.up*rayMargin), Vector3.up * upstairsRayDistance);
		RaycastHit2D[] hit = Physics2D.RaycastAll (transform.position+(Vector3.up*rayMargin),Vector3.up,upstairsRayDistance);

		switch (hit.Length) {
			case 0:
				{
					animator.enabled = false;
				}
				break;
			case 1:
				{
					animator.enabled = true;
					animator.speed = 1.5f;
				}
				break;
			case 2:
				{
					animator.enabled = true;
					animator.speed = 2;
				}
				break;
			case 3:
				{
					animator.enabled = true;
					animator.speed = 3f;
				}
				break;
		}
	}
}
