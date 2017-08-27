using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour {

	public SimpleAudioEvent clicksound;

	void OnMouseDown()
	{
		clicksound.PlayOneShot (SoundManager.sfxPlayer);
		Debug.Log (gameObject.name);
	}
}
