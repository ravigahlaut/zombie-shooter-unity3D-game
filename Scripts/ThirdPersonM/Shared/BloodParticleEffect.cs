using UnityEngine;
using System.Collections;


public class BloodParticleEffect : MonoBehaviour
{
	ParticleSystem blood;
	// Use this for initialization
	void Start ()
	{
		blood = GetComponentInChildren<ParticleSystem> ();
		blood.Play ();
		Destroy (gameObject, 3);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}



}

