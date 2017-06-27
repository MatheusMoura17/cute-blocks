using UnityEngine;
using System.Collections;

public enum GameSound
{
	CLICK, 
	EXPLOSION,
	GAME_OVER,
	PICKUP,
	VOICE_1,
	VOICE_2,

	FEMALE_VOICE_1,
	FEMALE_VOICE_2,
	FEMALE_VOICE_3
};

public enum GameMusic
{
	MENU, 
	GAMEPLAY
};

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {

	public AudioClip click;
	public AudioClip explosion;
	public AudioClip gameOver;
	public AudioClip pickup;
	public AudioClip voice1;
	public AudioClip voice2;

	public AudioClip femaleVoice1;
	public AudioClip femaleVoice2;
	public AudioClip femaleVoice3;

	public static AudioManager instance;
	private AudioSource audiosource;
	public AudioSource musicSource;

	// Musics
	public AudioClip menu;
	public AudioClip gameplay;

	void Awake()
	{
		instance = this;

		if (instance == null)
		{			
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
		else if (instance != this)
		{
			Destroy (gameObject);
		}

		audiosource = GetComponent<AudioSource> ();	
	}

	public static void PlaySound(GameSound sound){
		switch (sound) {

		case GameSound.CLICK:
			{
				instance.audiosource.PlayOneShot (instance.click);
			}
			break;

		case GameSound.EXPLOSION:
			{
				instance.audiosource.PlayOneShot (instance.explosion);
			}
			break;

		case GameSound.GAME_OVER:
			{
				instance.audiosource.PlayOneShot (instance.gameOver);
			}
			break;

		case GameSound.PICKUP:
			{
				instance.audiosource.PlayOneShot (instance.pickup);
			}
			break;

		case GameSound.VOICE_1:
			{
				instance.audiosource.PlayOneShot (instance.voice1);
			}
			break;

		case GameSound.VOICE_2:
			{
				instance.audiosource.PlayOneShot (instance.voice2);
			}
			break;

		case GameSound.FEMALE_VOICE_1:
			{
				instance.audiosource.PlayOneShot (instance.femaleVoice1);
			}
			break;

		case GameSound.FEMALE_VOICE_2:
			{
				instance.audiosource.PlayOneShot (instance.femaleVoice2);
			}
			break;

		case GameSound.FEMALE_VOICE_3:
			{
				instance.audiosource.PlayOneShot (instance.femaleVoice3);
			}
			break;

		}
	}

	public static void PlayMusic(GameMusic music, bool loop){
		switch (music) {

		case GameMusic.MENU:
			{
				if (!instance.musicSource.isPlaying) {
					instance.musicSource.loop = loop;
					instance.musicSource.clip = instance.menu;
					instance.musicSource.Play ();

				}
			}
			break;

		case GameMusic.GAMEPLAY:
			{
				if (!instance.musicSource.isPlaying) {
					instance.musicSource.loop = loop;
					instance.musicSource.clip = instance.gameplay;
					instance.musicSource.Play ();
				}
			}
			break;
		}
	}

	public static void SetSoundVolume(int value){
		instance.audiosource.volume = value;
	}

	public static void SetMusicVolume(int value){
		instance.musicSource.volume = value;
	}

	public static void StopMusic()
	{
		instance.musicSource.Stop ();
	}
}
