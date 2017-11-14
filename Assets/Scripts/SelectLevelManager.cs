using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevelManager : MonoBehaviour {

	public Button[] levelButtons;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("level-unlocked1", 1);
		for (int i = 0; i < levelButtons.Length; i++) {
			levelButtons[i].interactable=PlayerPrefs.GetInt ("level-unlocked" + (i+1)) == 1;
		}
	}

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }

	public void LoadLevel(int levelNumber){
		SceneManager.LoadScene("Level"+levelNumber);
	}
}
