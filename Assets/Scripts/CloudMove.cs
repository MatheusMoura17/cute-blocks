using UnityEngine;
using System.Collections;

public class CloudMove : MonoBehaviour {

	public Vector3 finalPos;
	public Vector3 resetPos;

	public float moveSpeed = 0.2f;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);

		if (transform.position.x >= finalPos.x)
			transform.position = resetPos;
	}
}
