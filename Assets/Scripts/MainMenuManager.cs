using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public GameObject main;
	public GameObject credits;
	public Animator fader;

	public string nextScene;
	public string moreGamesUrl;

	void Start()
	{
		fader.SetTrigger ("FadeOut");
	//	AudioManager.PlayMusic (GameMusic.MENU, true);
	}


	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}


	public void OnClick(string action){
		if (action == "Play") {			
			SceneManager.LoadScene (nextScene);
		} else if (action == "Credits") {
			main.SetActive (false);
			credits.SetActive (true);
			fader.SetTrigger ("FadeOut");
		} 
		else if (action == "MoreGames") {
			Application.OpenURL(moreGamesUrl);
		}
		else if (action == "Back") {
			main.SetActive (true);
			credits.SetActive (false);
			fader.SetTrigger ("FadeOut");
		}
	}
}