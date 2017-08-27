using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour {

	[SerializeField]
	float scoreAmount;

	public void HandleScore(ScoreManager sm)
	{
		sm.Score += scoreAmount;
	}
}
