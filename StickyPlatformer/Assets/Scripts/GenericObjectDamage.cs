using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectDamage : MonoBehaviour, IDamageable{

	[SerializeField]
	int damageInstances;

	public SimpleAudioEvent destroySound;

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
		destroySound.PlayOneShot (SoundManager.sfxPlayer);
		Destroy (gameObject);
	}
}
