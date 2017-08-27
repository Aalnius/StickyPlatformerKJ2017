using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName="Audio Events/Simple")]
public class SimpleAudioEvent : AudioEvent
{
	public AudioClip[] clips;

	public RangedFloat volume;

	[MinMaxRange(0, 2)]
	public RangedFloat pitch;

	public bool music;

	public override void Play(AudioSource source)
	{
		if (clips.Length == 0) return;
		int temp = Random.Range (0, clips.Length);
		SetupSound (source);
		source.clip = clips[temp];
		source.Play();
	}
	public override void PlayOneShot(AudioSource source)
	{
		if (clips.Length == 0) return;
		int temp = Random.Range (0, clips.Length);
		SetupSound (source);
		source.PlayOneShot (clips [temp]);
	}


	void SetupSound(AudioSource source)
	{
		source.volume = Random.Range(volume.minValue, volume.maxValue);
		if (music) {
			source.volume *= PlayerPrefs.GetFloat ("MusicVolume", 1);
		} else {
			source.volume *= PlayerPrefs.GetFloat ("SoundEffectsVolume", 1);
		}

		source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
	}
}