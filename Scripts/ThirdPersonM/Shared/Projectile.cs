using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
	[SerializeField]float speed;
	[SerializeField]float timeToLive;
	[SerializeField]float damage;
	[SerializeField]BloodParticleEffect bloodEffect;

	void Start(){
		Destroy (gameObject, timeToLive);

	}

	void Update(){
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		var destructable = other.transform.GetComponent<Destructable> ();
		if (destructable == null) {
			Debug.Log ("destrutable null");
			return;
		} else {
			Debug.Log ("destrutable not null");
		}


		destructable.TakeDamage (damage);
		Instantiate (bloodEffect, other.transform);

		Destroy (gameObject);

	}

}

