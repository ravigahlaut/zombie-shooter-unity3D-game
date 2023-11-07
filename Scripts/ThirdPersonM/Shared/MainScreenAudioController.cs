using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class MainScreenAudioController : MonoBehaviour
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
		print ("PLayig");
		if (!canPlay)
			return;
		

		canPlay = false;

		int clipIndex = Random.Range (0, clips.Length);
		AudioClip clip = clips [clipIndex];
		source.PlayOneShot (clip);
	}

	public void Stop(){
		source.Stop ();
		canPlay = false;
	}
}

