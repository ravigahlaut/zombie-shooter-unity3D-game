﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour {
	[SerializeField]float rateOfFire;
	[SerializeField]Projectile projectile;
	[SerializeField]Transform hand;
	[SerializeField] AudioController audioShoot;
	[SerializeField]AudioController audioReload;


	[SerializeField]BloodParticleEffect bloodEffect;

	[HideInInspector]public Transform muzzle;

	float nextFireAllowed;
	public bool canFire;
	private ParticleSystem muzzleFireParticleSystem;



	private WeaponReloader reloader;

	void Start(){
		muzzle = transform.Find ("Muzzle");

		reloader = GetComponent<WeaponReloader> ();
		muzzleFireParticleSystem = muzzle.gameObject.GetComponentInChildren<ParticleSystem> ();
		transform.SetParent (hand);
		//muzzle.transform.rotation = Quaternion.LookRotation (crosshair.transform.position);

	}

	public void Reload() {
		if (reloader == null)
			return;
		reloader.Reload ();
		audioReload.Play ();
	}

	public virtual void Fire() {
		
		canFire=false;
		if (Time.time < nextFireAllowed)
			return;
		if (reloader != null) {
			if (reloader.IsReloading)
				return;
			if (reloader.RoundsRemainingInClip == 0)
				return;
			reloader.TakeFromClip (1);
		}
			

		nextFireAllowed = Time.time + rateOfFire;

		//Instantiate the projectile

		Instantiate(projectile,muzzle.position,muzzle.rotation);


			
		audioShoot.Play ();
		if (muzzleFireParticleSystem != null)
			muzzleFireParticleSystem.Play ();
		canFire = true;

	}
}
