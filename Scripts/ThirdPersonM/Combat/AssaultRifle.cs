using UnityEngine;
using System.Collections;

public class AssaultRifle : Shooter
{
	public override void Fire(){
		base.Fire ();

		if (canFire) {
			
		}
	}

	public void Update(){
		if (GameManagers.Instance.InputMan.Reload) {
			Reload ();
		}
	}
}

