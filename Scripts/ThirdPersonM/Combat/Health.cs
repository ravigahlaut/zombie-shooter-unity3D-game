using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : Destructable
{

	float inSeconds=4;
	GameObject go;
	ZombieAI zombie;



	public override void Die(){
		

		if (!zombie.isDead) {
			base.Die ();

			zombie.ZombieDead ();
			GameManagers.Instance.Respawner.Despawn (gameObject, inSeconds);
			GameManagers.Instance.WaveManager.AnEnemyIsDead ();
			GameManagers.Instance.KillScore.OneMoreKilled ();
		}
	}

	void OnEnable(){
		Reset ();
		zombie = GetComponent<ZombieAI> ();
	}


	public override void TakeDamage(float amount){
		if (!zombie.isDead) {
			print ("Remaining: " + HitPointsRemaining);
			base.TakeDamage (amount);
		}
	}
}

