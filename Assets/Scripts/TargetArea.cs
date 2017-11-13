using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetArea : MonoBehaviour {

	public string itemTag="Item";
	public List<GameObject> linkedItems;

	// Use this for initialization
	void Start () {
		linkedItems = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.CompareTag(itemTag) && !linkedItems.Contains (collider.gameObject))
			linkedItems.Add (collider.gameObject);
	}

	void OnTriggerExit2D(Collider2D collider){
		if(collider.gameObject.CompareTag(itemTag) && linkedItems.Contains (collider.gameObject))
			linkedItems.Remove (collider.gameObject);
	}
}
