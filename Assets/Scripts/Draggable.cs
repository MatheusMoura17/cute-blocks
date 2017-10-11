using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(TargetJoint2D))]
public class Draggable : MonoBehaviour {

	private bool dragging;

	private TargetJoint2D targetJoin;
	private LineRenderer lineRenderer;

	void Start(){
		targetJoin = GetComponent<TargetJoint2D> ();
		lineRenderer = GetComponent<LineRenderer> ();
		targetJoin.enabled = false;
	}

	void Update () {
		if (dragging) {
			//movement
			Vector2 targetPosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			targetPosition=Camera.main.ScreenToWorldPoint (targetPosition);
			targetJoin.target = targetPosition;

			//line effect
			lineRenderer.SetPositions (new Vector3[]{ transform.position, targetPosition });
		}
	}

	void OnMouseDown(){
		dragging = true;
		lineRenderer.enabled = true;
		targetJoin.enabled = true;
	}

	void OnMouseUp(){
		dragging = false;
		lineRenderer.enabled = false;
		targetJoin.enabled = false;
	}
		
}
