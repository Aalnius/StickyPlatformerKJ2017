using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyObject : MonoBehaviour,ISticky,IDamageable {

	[SerializeField]
	Transform _transform;

	[SerializeField]
	Collider2D col;

	[SerializeField]
	bool canStick, canUnstick, launched;

	Transform playerTrans;

	Vector2 launchDir;

	[SerializeField]
	float launchSpeed, launchTimer;

	Rigidbody2D rb;

	[SerializeField]
	int damageInstances;

	public SimpleAudioEvent stickSound;

	// Use this for initialization
	void Start () {
		canStick = true;
		rb = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
//		if(launched)
//		{
//			_transform.Translate (moveDir * launchSpeed);
//		}
	}

	public void AttachToPlayer(Transform _playerTrans, List<StickyObject> stuckObjects)
	{
		if (canStick)
		{
			Destroy (rb);
			_transform.SetParent (_playerTrans);
			playerTrans = _playerTrans;
			col.usedByComposite = true;
			stuckObjects.Add (this);
			canStick = false;
			canUnstick = true;
			stickSound.PlayOneShot (SoundManager.sfxPlayer);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(launched)
		{
			IDamageable dmgScript = col.collider.GetComponent <IDamageable>();
			if(dmgScript != null)
			{
				dmgScript.TakeDamage (this);
			}
		}
	}

	public void TakeDamage(StickyObject damageDealer)
	{
		if(launched == false)
		{
			damageInstances--;
			damageDealer.KillMyself ();
			if (damageInstances <= 0)
			{
				
				KillMyself ();
			}
		}
	}
		

	public void KillMyself()
	{
		Destroy (gameObject);
	}

	void LaunchObject()
	{
		float playerDist = (playerTrans.position - _transform.position).magnitude;
		Vector2 playerDir = (playerTrans.position - _transform.position) / playerDist;
		launchDir = -playerDir;
		//you need to make the object launch off from the player then hang in the air
		rb.AddForce (launchDir * launchSpeed);
		StartCoroutine (Launch ());
	}

	IEnumerator Launch()
	{
		launched = true;
		yield return new WaitForSeconds (launchTimer);
		launched = false;
		canStick = true;
		rb.gravityScale = 1;

	}

	public void DetatchFromPlayer(List<StickyObject> stuckObjects)
	{
		if(canUnstick)
		{
			canUnstick = false;
			_transform.SetParent (null);
			rb = gameObject.AddComponent <Rigidbody2D> ();
			rb.gravityScale = 0;
			col.usedByComposite = false;
			stuckObjects.Remove (this);
			LaunchObject ();
			playerTrans = null;
		}
	}


}
