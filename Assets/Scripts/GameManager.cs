using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Animator animatorGameWin;
	public Animator animatorGameOver;
	public Animator animatorStartGame;
	public Text timerText;
	public Text objeciveText;
	public Text descText;

	public int itemsToWin=3;
	private TargetArea[] targetAreas;

	private bool gameStarted;
	public float time=15;

	public int nextLevel;

	void Start () {
		objeciveText.text = itemsToWin.ToString();
		descText.text = string.Format ("Colete {0} items em {1} segundos", itemsToWin, time);
		animatorStartGame.SetTrigger ("show");
        targetAreas = FindObjectsOfType<TargetArea> ();
		foreach (TargetArea area in targetAreas)
			area.onLinkItem = OnLinkItem;
	}

	void OnLinkItem(){
		int linkedItemsCount = 0;
		foreach (TargetArea area in targetAreas)
			linkedItemsCount+=area.linkedItems.Count;

		if (itemsToWin <= linkedItemsCount)
			SetGameWin ();
	}

	public void StartGame(){
		animatorStartGame.SetTrigger ("hide");
		gameStarted = true;
	}

	public void BackToMenu(){
		SceneManager.LoadScene ("MainMenu");
	}

	public void Restart(){
		SceneManager.LoadScene (Application.loadedLevel);
	}

	public void NextLevel(){
		SceneManager.LoadScene ("Level" + nextLevel);
	}

	private void SetGameWin(){
		PlayerPrefs.SetInt ("level" + nextLevel, 1);
		gameStarted = false;
		animatorGameWin.SetTrigger("show");
    }

	private void SetGameOver(){
		gameStarted = false;
		animatorGameOver.SetTrigger("show");
	}

	void Update () {
		if (gameStarted) {
			if (time > 0) {
				time -= Time.deltaTime;
				timerText.text = time.ToString ("00");
			} else {
				SetGameOver ();
			}
		}
	}
}
