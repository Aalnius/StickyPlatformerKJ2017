using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	[SerializeField]
	float score;

	public Text scoreText;


	public void CalculateScore(GameObject player)
	{
		List<StickyObject> capturedObjects = player.GetComponent <StickyCollision> ().StuckObjects;


		foreach (var item in capturedObjects)
		{
			ScoreObject scoreScript = item.GetComponent <ScoreObject>();
			if (scoreScript)
			{
				scoreScript.HandleScore (this);
			}
		}

		scoreText.text = score.ToString ();
	}
		

	public float Score
	{
		get
		{
			return score;
		}
		set
		{
			score = value;
		}
	}
}
