using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static AudioSource sfxPlayer;

	AudioSource musicPlayer;

	// Use this for initialization
	void Awake () {
		sfxPlayer = GetComponent <AudioSource> ();
		musicPlayer = GameObject.FindGameObjectWithTag ("MusicPlayer").GetComponent <AudioSource>();
	
	}

	public void ToggleSFX()
	{
		sfxPlayer.mute = !sfxPlayer.mute;
	}

	public void ToggleMusic()
	{
		musicPlayer.mute = !musicPlayer.mute;
	}
}
