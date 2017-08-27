using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

	public AudioClip[] music;

	private static MusicPlayer _instance;

	AudioSource audioPlayer;

	bool picking;

	int currentMusicIndex = 0;


	public void OnEnable()
	{
		_instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public void Awake()
	{
		if (_instance) {
			DestroyImmediate (gameObject);
		} else {
			audioPlayer = GetComponent <AudioSource> ();
		}
	}
		
	
	// Update is called once per frame
	void Update () {

		if (!audioPlayer.isPlaying && picking == false) {
			picking = true;
			audioPlayer.clip = PickMusic();
			audioPlayer.Play ();

			if (audioPlayer.isPlaying == true) {
				picking = false;
			}
		}
	}

	AudioClip PickMusic()
	{
		
		int temp = Random.Range (0, music.Length);; 
		while(temp == currentMusicIndex)
		{
			temp = Random.Range (0, music.Length);
		}
		currentMusicIndex = temp;
		return music [currentMusicIndex];
	}
		
	public void ToggleMusic()
	{
		audioPlayer.mute = !audioPlayer.mute;
	}


}
