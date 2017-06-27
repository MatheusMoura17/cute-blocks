using UnityEngine;
using System.Collections;

public class NoDragArea : MonoBehaviour {

	private MouseManager mouseManager;

	void Awake()
	{
		mouseManager = FindObjectOfType<MouseManager> ();
	}

	void OnMouseOver()
	{		
		mouseManager.Drop ();
	}
}
