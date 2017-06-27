using UnityEngine;
using System.Collections;

public class BlinkEyes : MonoBehaviour {

	public float blinkRate;
	private float currentTimeToBlink;
	public float blinkDelay = 1f;

	public GameObject noBlink;
	public GameObject blink;

	public bool randomBlink;
	public float maxBlinkRate = 7;

	// Use this for initialization
	void Start () {
		noBlink.SetActive (true);
		blink.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		currentTimeToBlink += Time.deltaTime;
		if (currentTimeToBlink >= blinkRate) {
			currentTimeToBlink = 0;

			if (randomBlink) {
				blinkRate = Random.Range (blinkRate, maxBlinkRate);
			}

			StartCoroutine ("Blink");
		}
	}

	IEnumerator Blink(){
		noBlink.SetActive (false);	
		blink.SetActive (true);
		yield return new WaitForSeconds (blinkDelay);
		noBlink.SetActive (true);
		blink.SetActive (false);
	}
}
