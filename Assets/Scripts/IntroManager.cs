using UnityEngine;
using System.Collections;

public enum SingleState
{
	ROTATE_90_1,
	ROTATE_90_2,
	VOICE_1,
	VOICE_2,
	NONE}
;

public enum MultiState
{
	MOVE_LEFT,
	MOVE_RIGHT,
	VOICE_1,
	VOICE_2,
	VOICE_3,
	NONE}
;

public class IntroManager : MonoBehaviour
{

	public GameObject[] introObjectsToDesable;
	public float[] listIntroSpeed;
	private float introSpeed;
	private float currentIntroSpeed;

	public SingleState currentIntroState = SingleState.NONE;
	public GameObject targetIntro;
	public GameObject targetIntro2;

	private int currentState;
	private MouseManager mouseManager;

	public bool introCompleted;

	public float targetTorque;
	public float targetForce;

	public GameObject targetBallon1;
	public GameObject targetBallon2;
	public GameObject targetBallon3;

	public SpriteRenderer targetMouth;
	public SpriteRenderer targetMouth2;
	public Sprite[] mouths;

	public float mouthRate = 2f;
	private float currentTimeToMouth;
	private bool movingMouth;
	private int currentMouth;

	public bool startWithIntro = true;
	public bool resetStartPos;
	public Transform startPos;

	private bool firstBlock;
	public bool isMultiIntro;

	// Use this for initialization
	void Start ()
	{

		if (!startWithIntro) {
			FinishIntro ();

			if (resetStartPos) {
				targetIntro.transform.position = startPos.position;
				targetIntro.transform.rotation = Quaternion.identity;
			}
		} 

		ToggleIntroObjects (false);
		introSpeed = listIntroSpeed [0];
		mouseManager = FindObjectOfType<MouseManager> ();
		mouseManager.enabled = false;
		targetBallon1.SetActive (false);
		targetBallon2.SetActive (false);

		if (isMultiIntro)
			targetBallon3.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (!introCompleted) {
			
			if (isMultiIntro) {
				
				currentIntroSpeed += Time.deltaTime;

				if (currentIntroSpeed > introSpeed) {
					currentIntroSpeed = 0;

					currentState++;

					if (currentState > 5) {
						FinishIntro ();
					}

					if (currentState == 1) {
						print ("1");
						ChangeMultiState (MultiState.MOVE_RIGHT);
						introSpeed = listIntroSpeed [1];

					} else if (currentState == 2) {
						print ("2");
						ChangeMultiState (MultiState.MOVE_LEFT);
						introSpeed = listIntroSpeed [2];

					} else if (currentState == 3) {
						print ("3");
						ChangeMultiState (MultiState.VOICE_1);
						introSpeed = listIntroSpeed [3];

					} else if (currentState == 4) {
						print ("4");
						ChangeMultiState (MultiState.VOICE_2);
						introSpeed = listIntroSpeed [4];
						
					} else if (currentState == 5) {
						print ("5");
						ChangeMultiState (MultiState.VOICE_3);
						introSpeed = listIntroSpeed [5];

					}
				}
			} 
			else
			{

				currentIntroSpeed += Time.deltaTime;

				if (currentIntroSpeed > introSpeed) {
					currentIntroSpeed = 0;

					currentState++;

					if (currentState > 4) {
						FinishIntro ();
					}

					if (currentState == 1) {
						print ("1");
						ChangeSingleState (SingleState.ROTATE_90_1);
						introSpeed = listIntroSpeed [1];

					} else if (currentState == 2) {
						print ("2");
						ChangeSingleState (SingleState.ROTATE_90_2);
						introSpeed = listIntroSpeed [2];

					} else if (currentState == 3) {
						print ("3");
						ChangeSingleState (SingleState.VOICE_1);
						introSpeed = listIntroSpeed [3];

					} else if (currentState == 4) {
						print ("4");
						ChangeSingleState (SingleState.VOICE_2);
						introSpeed = listIntroSpeed [4];

					}
				}
			}
		}

		if (introCompleted && !mouseManager.enabled) {
			ToggleIntroObjects (true);
			mouseManager.enabled = true;
		}

		if (movingMouth) {
			currentTimeToMouth += Time.deltaTime;
			if (currentTimeToMouth > mouthRate) {
				currentTimeToMouth = 0;

				currentMouth++;

				if (currentMouth > mouths.Length - 1) {
					currentMouth = 0;
					movingMouth = false;
				}

				if (firstBlock) {
					targetMouth.sprite = mouths [currentMouth];
				}
				else
				{
					if (isMultiIntro) {
						targetMouth2.sprite = mouths [currentMouth];
					}
				}
			}
		}
	}

	private void FinishIntro ()
	{
		introCompleted = true;

		targetBallon2.SetActive (false);

		if(isMultiIntro)
		targetBallon3.SetActive (false);
		
		ChangeSingleState (SingleState.NONE);
		ChangeMultiState (MultiState.NONE);

		targetMouth.sprite = mouths [0];

		if(isMultiIntro)
		targetMouth2.sprite = mouths [0];

		movingMouth = false;
		print ("intro completada");
	}

	public void ChangeMultiState (MultiState intro)
	{
		switch (intro) {

		case MultiState.MOVE_RIGHT:
			{					
				targetIntro.GetComponent<Rigidbody2D> ().AddForce (transform.up * 50);
				targetIntro.GetComponent<Rigidbody2D> ().AddForce (transform.right * targetForce);

				Quaternion rot = targetIntro.transform.rotation;
				rot.x = 0; //null rotation X
				rot.z = 0; //null rotation Z
				targetIntro.transform.rotation = rot;
			}
			break;

		case MultiState.MOVE_LEFT:
			{
				targetIntro2.GetComponent<Rigidbody2D> ().AddForce (transform.up * 50);
				targetIntro2.GetComponent<Rigidbody2D> ().AddForce (-transform.right * targetForce);

				Quaternion rot = targetIntro2.transform.rotation;
				rot.x = 0; //null rotation X
				rot.z = 0; //null rotation Z
				targetIntro2.transform.rotation = rot;

			}
			break;

		case MultiState.VOICE_1:
			{
				targetBallon1.SetActive (true);			
				AudioManager.PlaySound (GameSound.FEMALE_VOICE_1);
				movingMouth = true;

				firstBlock = true;
			}
			break;

		case MultiState.VOICE_2:
			{
				targetBallon1.SetActive (false);		
				targetBallon2.SetActive (true);
				AudioManager.PlaySound (GameSound.FEMALE_VOICE_2);
				movingMouth = true;

				firstBlock = false;
			}
			break;

		case MultiState.VOICE_3:
			{
				targetBallon2.SetActive (false);		
				targetBallon3.SetActive (true);
				AudioManager.PlaySound (GameSound.FEMALE_VOICE_3);
				movingMouth = true;

				firstBlock = true;
			}
			break;
		}
	}


	public void ChangeSingleState (SingleState intro)
	{
		switch (intro) {

		case SingleState.ROTATE_90_1:
			{					
				targetIntro.GetComponent<Rigidbody2D> ().AddForce (transform.right * targetForce);
				targetIntro.GetComponent<Rigidbody2D> ().AddTorque (targetTorque);

			}
			break;

		case SingleState.ROTATE_90_2:
			{
				targetIntro.GetComponent<Rigidbody2D> ().AddForce (transform.right * targetForce);
				targetIntro.GetComponent<Rigidbody2D> ().AddTorque (targetTorque);

				Quaternion rot = targetIntro.transform.rotation;
				rot.x = 0; //null rotation X
				rot.z = 0; //null rotation Z
				targetIntro.transform.rotation = rot;

			}
			break;

		case SingleState.VOICE_1:
			{
				targetBallon1.SetActive (true);			
				AudioManager.PlaySound (GameSound.VOICE_1);
				movingMouth = true;

				firstBlock = true;
			}
			break;

		case SingleState.VOICE_2:
			{
				targetBallon1.SetActive (false);		
				targetBallon2.SetActive (true);
				AudioManager.PlaySound (GameSound.VOICE_2);
				movingMouth = true;

				firstBlock = true;
			}
			break;
		}
	}

	void ApplyForce (Rigidbody2D body)
	{
		Vector3 direction = body.transform.position - transform.position;
		body.AddForceAtPosition (direction.normalized, transform.position);
	}

	public void ToggleIntroObjects (bool active)
	{
		for (int i = 0; i < introObjectsToDesable.Length; i++) {
			introObjectsToDesable [i].SetActive (active);
		}
	}
}
