using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
	[SerializeField]AudioClip[] clips;
	[SerializeField]float minDelaybtwClips;

	bool canPlay;
	AudioSource source;

	// Use this for initialization
	void Start ()
	{
		source = GetComponent<AudioSource> ();
		canPlay = true;
	}
	
	public void Play(){
		if (!(PlayerPrefs.GetInt ("AudioON", 1) == 0)) {
			print ("PLayig");
			if (!canPlay)
				return;
			GameManagers.Instance.Timer.Add (() => {
				canPlay = true;
			}, minDelaybtwClips);

			canPlay = false;

			int clipIndex = Random.Range (0, clips.Length);
			AudioClip clip = clips [clipIndex];
			source.PlayOneShot (clip);
		}
	}
}

