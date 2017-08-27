using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObject : MonoBehaviour, IDamageable {
	[SerializeField]
	int damageInstances;

	bool dead;

	public SimpleAudioEvent collectSound;

	// Use this for initialization
	void Awake () {
		GameManager.goalObjects++;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.collider.tag == "Player")
		{
			KillMyself ();
		}
		else if(coll.collider.tag == "StickyObject")
		{
			TakeDamage (coll.gameObject.GetComponent <StickyObject>());
		}
	}

	public void TakeDamage(StickyObject damageDealer)
	{
		damageInstances--;
		damageDealer.KillMyself ();
		if(damageInstances <= 0)
		{
			KillMyself ();
		}
	}



	public void KillMyself()
	{
		if (dead == false)
		{
			dead = true;
			collectSound.PlayOneShot (SoundManager.sfxPlayer);
			GameManager.goalObjects--;
			GameManager.WinCheck();
			Destroy (gameObject);
		}
	}
}
