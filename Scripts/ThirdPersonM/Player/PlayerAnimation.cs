using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
	 Animator animator;
	bool deadAnimationPlayed=false;
	PlayerAim playeraim;
	private PlayerAim PlayerAim{
		get{ 
			if (playeraim == null) {
				playeraim = GameManagers.Instance.LocalPlayer.playeraim;
			}
			return playeraim;
		}
	}

	void Awake ()
	{
		animator = GetComponentInChildren<Animator> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!GameManagers.Instance.GameState.IsPaused ()) {
			if (!GetComponent<Player> ().playerDead) {
				animator.SetFloat ("Vertical", GameManagers.Instance.InputMan.Vertical);
				//TimeStamp 17:08 :: E11
				animator.SetFloat ("Horizontal", GameManagers.Instance.InputMan.Horizontal);
				animator.SetFloat ("aimAngle", PlayerAim.getAngle ());
			} else {
				if (!deadAnimationPlayed) {
					animator.SetTrigger ("isDead");
					deadAnimationPlayed = true;
				}
			}
		}
	}
}

