using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

	[SerializeField]Shooter assaultRifle;

	void Update(){
		if (!GameManagers.Instance.GameState.IsPaused ()) {
			if (GameManagers.Instance.InputMan.Fire1) {
				assaultRifle.Fire ();
			}
		}
	}
}
