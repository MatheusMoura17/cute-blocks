using UnityEngine;
using System.Collections;

public class MoveUI : MonoBehaviour {

	public float moveSpeed;
	public bool loop;

	public Vector3 positionToGo;
	private Vector3 startPos;
	private Vector3 startPosToGo;
	private RectTransform rectTrans;

	void Awake()
	{
		rectTrans = GetComponent<RectTransform> ();
	}

	// Use this for initialization
	void Start () {
		startPos = rectTrans.localPosition;
		startPosToGo = positionToGo;
	}
	
	// Update is called once per frame
	void Update () {
		rectTrans.localPosition = Vector3.MoveTowards(rectTrans.localPosition, positionToGo, moveSpeed * Time.deltaTime);

		if (loop && rectTrans.localPosition == positionToGo) {
			positionToGo = startPos;
		}

		if (loop && rectTrans.localPosition == startPos) {
			positionToGo = startPosToGo;
		}
	}
}
