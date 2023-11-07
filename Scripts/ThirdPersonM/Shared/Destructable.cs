using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour
{

	[SerializeField]float HitPoints;

	public event System.Action OnDeath;
	public event System.Action OnDamageRecieved;

	float damageTaken;

	public float HitPointsRemaining {
		get{ 
			return HitPoints - damageTaken;
		}
	}

	public bool isAlive{
		get{ 
			return HitPointsRemaining > 0;
		}
	}

	public virtual void Die(){
		if (isAlive)
			return;

		if (OnDeath != null)
			OnDeath ();
	}

	public virtual void TakeDamage(float amount){
		damageTaken += amount;

		if (OnDamageRecieved != null)
			OnDamageRecieved ();

		if (HitPointsRemaining <= 0) {
			Die ();
		}
	}

	public void Reset(){
		damageTaken = 0;
	}
}

