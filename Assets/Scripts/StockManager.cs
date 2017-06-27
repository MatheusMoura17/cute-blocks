using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StockManager : MonoBehaviour
{

	public StockArea[] stocks;
	public Animator fader;
	public GameObject finished;
	public GameObject fail;
	public bool stockCompleted;
	public bool stockFail;
	public string nextScene;
	public string menuScene;

	public bool lastLevel;

	public bool checkOneBlock;
	public bool checkTwoBlocks;
	public bool CheckThreeBlocks;

	private GameObject[] blocks;

	void Start ()
	{
		fader.SetTrigger ("FadeOut");
		AudioManager.PlayMusic (GameMusic.GAMEPLAY, true);
		blocks = GameObject.FindGameObjectsWithTag ("Block");
	}

	void Update ()
	{
		if (stockCompleted) {
			if (Input.GetMouseButtonDown (0)) {
				StartCoroutine (NextLevel ());
			}
		}

		if (stockFail) {
			if (Input.GetMouseButtonDown (0)) {
				print ("Lembrar de pular o level falhado");
				StartCoroutine (NextLevel ());
			}
		}
	}

	public void CheckStocks ()
	{	

		if (checkOneBlock) {
			if (stocks [0].stockFinished && !stockCompleted) {
				StartCoroutine (LevelComplete ());		
			}
		}
		else if (checkTwoBlocks) {
			if (stocks [0].stockFinished && stocks [1].stockFinished && !stockCompleted) {
				StartCoroutine (LevelComplete ());		
			}
		}
		else if (CheckThreeBlocks) {
			if (stocks [0].stockFinished && stocks [1].stockFinished && stocks [2].stockFinished && !stockCompleted) {
				StartCoroutine (LevelComplete ());		
			}
		}			
	}

	public void HasLost ()
	{
		StartCoroutine (LevelFail ());
	}

	private	IEnumerator LevelFail ()
	{
		print ("Perdi");	
		fail.SetActive (true);

		for (int i = 0; i < blocks.Length; i++) {
			blocks [i].GetComponent<Rigidbody2D> ().isKinematic = true;
			blocks [i].GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}

		yield return new WaitForSeconds (0.5f);
		fader.SetTrigger ("FadeIn");
		stockFail = true;
		AudioManager.StopMusic ();
	}

	private IEnumerator LevelComplete ()
	{		
		print ("Ganhei");	
		finished.SetActive (true);

		for (int i = 0; i < blocks.Length; i++) {
			blocks [i].GetComponent<Rigidbody2D> ().isKinematic = true;
			blocks [i].GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}

		yield return new WaitForSeconds (0.5f);
		fader.SetTrigger ("FadeIn");
		stockCompleted = true;
		AudioManager.StopMusic ();
	}

	private IEnumerator NextLevel ()
	{
		yield return new WaitForSeconds (0.5f);	
		if (stockCompleted) {
			if (lastLevel) {
				SceneManager.LoadScene (menuScene);
			} else {
				SceneManager.LoadScene (nextScene);
			}

		} else if (stockFail) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}
}
