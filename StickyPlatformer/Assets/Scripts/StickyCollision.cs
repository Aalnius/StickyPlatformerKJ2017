using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyCollision : MonoBehaviour {

	[SerializeField]
	Transform _transform;

	[SerializeField]
	List<StickyObject> stuckObjects;

	public SimpleAudioEvent blowChunksSound;

	// Use this for initialization
	void Start () {
		stuckObjects = new List<StickyObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonUp ("BlowChunks"))
		{
			BlowChunks ();
		}
	}

	void BlowChunks()
	{
		for (int i = 0; i < stuckObjects.Count; i++)
		{
			StickyObject stickyObjScript = stuckObjects[i];
			if (stickyObjScript)
			{
				stickyObjScript.DetatchFromPlayer (stuckObjects);
				i--;
				blowChunksSound.PlayOneShot (SoundManager.sfxPlayer);
			}
		}

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		StickyObject stickyObjScript = coll.collider.GetComponent <StickyObject> ();
		if (stickyObjScript)
		{
			stickyObjScript.AttachToPlayer (_transform, stuckObjects);
		}
	}


	public List<StickyObject> StuckObjects
	{
		get
		{
			return stuckObjects;
		}
	}
}
