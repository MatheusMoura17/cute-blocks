using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.sceneCount - 1);
    }

    public void ChangeLevel(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }
}
