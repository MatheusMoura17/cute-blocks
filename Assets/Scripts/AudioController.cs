using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioController : MonoBehaviour {

	public Image buttonSound;
	public Image buttonMusic;

	public Sprite soundGraphicOn;
	public Sprite soundGraphicOff;

	public Sprite musicGraphicOn;
	public Sprite musicGraphicOff;

	public bool soundOn = true;
	public bool musicOn = true;

	public bool deleteAudioKeys;

	// Use this for initialization
	void Start () {

		if (deleteAudioKeys) {
			PlayerPrefs.DeleteKey ("ToggleSound");
			PlayerPrefs.DeleteKey ("ToggleMusic");
		}

		if (!PlayerPrefs.HasKey ("ToggleSound")) {
			ToggleSound ();
		} 

		if (!PlayerPrefs.HasKey ("ToggleMusic")) {
			ToggleMusic ();
		}

		RestoreToggleAudio();

	}

	public void OnClickSound(){
		soundOn = !soundOn;
		ToggleSound ();
	}

	public void ToggleSound(){
		if (soundOn) {
			buttonSound.sprite = soundGraphicOn;
			// Save to on
			PlayerPrefs.SetInt("ToggleSound", 1);
			PlayerPrefs.Save();
			AudioManager.SetSoundVolume (1);
		} else {
			buttonSound.sprite = soundGraphicOff;
			// Save to off
			PlayerPrefs.SetInt("ToggleSound", 0);
			PlayerPrefs.Save();
			AudioManager.SetSoundVolume (0);
		}
	}

	public void OnClickMusic(){
		musicOn = !musicOn;
		ToggleMusic ();
	}

	public void ToggleMusic(){
		if (musicOn) {
			buttonMusic.sprite = musicGraphicOn;
			// Save to on
			PlayerPrefs.SetInt("ToggleMusic", 1);
			PlayerPrefs.Save();	
			AudioManager.SetMusicVolume (1);
		} else {
			buttonMusic.sprite = musicGraphicOff;
			// Save to off
			PlayerPrefs.SetInt("ToggleMusic", 0);
			PlayerPrefs.Save();
			AudioManager.SetMusicVolume (0);
		}
	}

	private void RestoreToggleAudio(){
		AudioManager.SetSoundVolume (PlayerPrefs.GetInt("ToggleSound"));
		AudioManager.SetMusicVolume (PlayerPrefs.GetInt("ToggleMusic"));
	}
}
