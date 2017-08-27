using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static int goalObjects;

	bool gameWon;

	public delegate void GoalChecker();
	public static GoalChecker WinCheck;

	[SerializeField]
	GameObject player;

	[SerializeField]
	ScoreManager sm;

	public GameObject winCanvas;

	public string sceneName;

	public float levelEndTimer;

	public SimpleAudioEvent gameWonSound;

	void Start()
	{
		WinCheck = CheckForWin;
	}

	void Update()
	{
		if(Input.GetButtonUp ("Restart"))
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
		if(gameWon)
		{
			if(Input.GetButtonUp ("Exit"))
			{
				Application.Quit ();
			}
		}
	}

	void CheckForWin()
	{
		if(goalObjects <= 0)
		{
			gameWon = true;
			//trigger win stuff like balloons or something
			sm.CalculateScore (player);
			winCanvas.SetActive (true);
			gameWonSound.PlayOneShot (SoundManager.sfxPlayer);
			if(sceneName.Length >0)
			{
				StartCoroutine (LoadNextLevel ());
			}
		}
	}

	IEnumerator LoadNextLevel()
	{
		yield return new WaitForSeconds (levelEndTimer);
		SceneManager.LoadScene (sceneName);
	}
}
