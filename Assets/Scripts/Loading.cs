using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	public GameObject[] blocks;
	public string levelToLoad;
	public float timeToLoad = 3.0f;
	public Animator fader;

	public GameObject loading;

	IEnumerator Start(){		
		yield return new WaitForSeconds (timeToLoad);

		blocks [Random.Range (0, blocks.Length)].SetActive(true);

		fader.SetTrigger ("FadeIn");
		loading.SetActive (false);

		yield return new WaitForSeconds (1);

		ChangeLevel ();
	}

	void ChangeLevel() {
		SceneManager.LoadScene (levelToLoad);  
	}
}
