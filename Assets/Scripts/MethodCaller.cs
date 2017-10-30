using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MethodCaller : MonoBehaviour {

	public UnityEvent myEvent;

	public void Call(){
		myEvent.Invoke ();
	}
}
