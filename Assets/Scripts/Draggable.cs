using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Draggable : MonoBehaviour {

	public int damping = 7;
	private bool dragging;

	void Update () {
		if (dragging) {
			Vector2 targetPosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			targetPosition=Camera.main.ScreenToWorldPoint (targetPosition);
			transform.position = Vector2.Lerp(transform.position,targetPosition,damping*Time.deltaTime);
		}
	}

	void OnMouseDown(){
		dragging = true;
	}

	void OnMouseUp(){
		dragging = false;
	}
		
}
