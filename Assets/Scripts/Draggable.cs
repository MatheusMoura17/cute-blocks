using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Draggable : MonoBehaviour {

	public int damping = 7;
	private bool dragging;

	private Rigidbody2D myRigidbody;
	private LineRenderer lineRenderer;

	void Start(){
		myRigidbody = GetComponent<Rigidbody2D> ();
		lineRenderer = GetComponent<LineRenderer> ();
	}

	void Update () {
		if (dragging) {
			//movement
			Vector2 targetPosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			targetPosition=Camera.main.ScreenToWorldPoint (targetPosition);
			transform.position = Vector2.Lerp(transform.position,targetPosition,damping*Time.deltaTime);
			//line effect
			lineRenderer.SetPositions (new Vector3[]{ transform.position, targetPosition });
			myRigidbody.velocity = Vector2.zero;
		}
	}

	void OnMouseDown(){
		dragging = true;
		lineRenderer.enabled = true;
	}

	void OnMouseUp(){
		dragging = false;
		lineRenderer.enabled = false;
		//myRigidbody.Sleep ();
	}
		
}
