using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Draggable : MonoBehaviour {

	public int damping = 10;
	private bool dragging;
	
	// Update is called once per frame
	void Update () {
		if (dragging) {
			Vector2 targetPosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			targetPosition=Camera.main.ScreenToWorldPoint (targetPosition);
			transform.position = Vector2.Lerp(transform.position,targetPosition,damping*Time.deltaTime);
			//transform.position=targetPosition;
		}
	}

	void OnMouseDown(){
		dragging = true;
	}

	void OnMouseUp(){
		dragging = false;
	}
		
}
