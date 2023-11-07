using UnityEngine;
using System.Collections;

public class ZombieAttack : MonoBehaviour
{
	Player localPlayer;
	float cooldowntimer;
	Transform target;

	// Use this for initialization
	void Start ()
	{
		localPlayer = GameManagers.Instance.LocalPlayer;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		cooldowntimer = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!GameManagers.Instance.GameState.IsPaused()) {
			float distance = Vector3.Distance (target.position, transform.position);
			if (distance <3) {
				Attack ();
			}
			if (cooldowntimer > 0) {
				cooldowntimer -= Time.deltaTime;
			}
			if (cooldowntimer < 0) {
				cooldowntimer = 0;
			}
		}
	
	}

	void Attack(){
		if (cooldowntimer ==0&&!GetComponent<ZombieAI>().isDead && !GameManagers.Instance.GameState.IsPaused()) {
			localPlayer.GetComponent<Player> ().TakeDamage (5);
			cooldowntimer = 3;
		}
	}
}

