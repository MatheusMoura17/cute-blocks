using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int score;
	public Text scoreText;
	public bool resetScoreOnStart;

	void Start()
	{
		if (resetScoreOnStart)
			PlayerPrefs.DeleteKey ("Score");
		
		score = PlayerPrefs.GetInt("Score");
	}

	void Update() {		
		scoreText.text = "Total Stars: " + score;
	}

	public void AddScore()
	{
		score++;
		PlayerPrefs.SetInt ("Score", score);
	}

}
