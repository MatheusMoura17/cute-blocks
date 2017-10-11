using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(LineRenderer))]
public class Draggable : MonoBehaviour {

	public int damping = 7;
	private bool dragging;
	private LineRenderer lineRenderer;

	void Start(){
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
		}
	}

	void OnMouseDown(){
		dragging = true;
		lineRenderer.enabled = true;
	}

	void OnMouseUp(){
		dragging = false;
		lineRenderer.enabled = false;
	}
		
}
