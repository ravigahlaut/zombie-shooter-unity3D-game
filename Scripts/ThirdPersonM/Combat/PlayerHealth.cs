using UnityEngine;
using System.Collections;

public class PlayerHealth : Destructable
{

	public override void Die(){
		

			base.Die ();

		//GameManagers.Instance.Respawner.Despawn (GameObject.FindGameObjectWithTag ("Player"),0,null);
			
			

	}

	public override void TakeDamage(float amount){
		print ("Remaining: " + HitPointsRemaining);
		base.TakeDamage (amount);
	}

}

