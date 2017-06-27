using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public Text buttonTextTip;
	public Text buttonTextMenu;
	public GameObject tip;
	public GameObject menu;
	public GameObject buttonDesableGroup;

	private bool showTip = true;
	private bool showMenu = true;

	void Awake(){
		ToggleTip ();
		ToggleMenu ();
	}

	public void OnClickTip(){
		showTip = !showTip;
		ToggleTip ();
	}

	private void ToggleTip()
	{
		if (showTip) {
			tip.SetActive (true);
			buttonTextTip.text = "X";
		} else {
			tip.SetActive (false);
			buttonTextTip.text = "?";
		}
	}

	public void OnClickMenu(){
		showMenu = !showMenu;
		ToggleMenu ();
	}

	private void ToggleMenu()
	{
		if (showMenu) {
			menu.SetActive (false);
			buttonDesableGroup.SetActive (true);
			buttonTextMenu.text = "MENU";
		} else {
			menu.SetActive (true);
			buttonDesableGroup.SetActive (false);
			buttonTextMenu.text = "HIDE";
		}
	}

	public void OnClickRestart()
	{
		StartCoroutine(Restart());
	}

	private IEnumerator Restart()
	{
		yield return new WaitForSeconds (0.5f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
