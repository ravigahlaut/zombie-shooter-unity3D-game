using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour {

	Transform target;
	NavMeshAgent agent;
	Animator animator;
	bool isWalker=false;
	bool isCrawler=false;
	bool attackType2=false;
	public bool isDead=false;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.speed = Random.Range (0.5f,3.0f);
		if (agent.speed < 1.0f) {
			isWalker = true;
		}
		if (Random.Range (1.0f, 2.0f) > 1.5f) {
			attackType2 = true;
		}
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		animator = GetComponentInChildren<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead&& !(GameManagers.Instance.GameState.IsPaused())) {
			float distance = Vector3.Distance (transform.position, target.position);


			if (distance > 2.5 ) {
				agent.updatePosition = true;
				agent.SetDestination (target.position);
				if (!isWalker) {
					animator.SetBool ("isRunning", true);
				} else {
					animator.SetBool ("isWalking", true);
				}
				if (attackType2) {
					animator.SetBool ("isAttacking2", false);
				} else {
					animator.SetBool ("isAttacking", false);
				}
			} else {
				agent.updatePosition = false;
				if (!isWalker) {
					animator.SetBool ("isRunning", false);
				} else {
					animator.SetBool ("isWalking", false);
				}
				if (attackType2) {
					animator.SetBool ("isAttacking2", true);
				} else {
					animator.SetBool ("isAttacking", true);
				}


			}

		}
	}

	public void ZombieDead(){
		if (!isDead && !GameManagers.Instance.GameState.IsPaused()) {
			if (Random.Range (0, 9) > 5) {
				animator.SetTrigger ("isDead");
			} else {
				animator.SetTrigger ("isDead2");
			}
			agent.updatePosition = false;
			gameObject.GetComponent<CapsuleCollider> ().enabled = false;
			GameManagers.Instance.BloodCanvasEffect.KillEffect ();
			isDead = true;
		}
		
	}
}
