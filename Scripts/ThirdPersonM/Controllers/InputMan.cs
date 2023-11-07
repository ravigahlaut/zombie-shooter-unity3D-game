using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMan : MonoBehaviour {

	public float Vertical;
	public float Horizontal;
	public Vector2 MouseInput;
	public bool Fire1;
	public bool Reload;

	 VirtualJoystick joystick;
	public MouseController mouseControl;
	UIbuttons fire;
	ReloadButton reload;

	void Awake(){
		DontDestroyOnLoad (this);
		joystick = GameObject.FindGameObjectWithTag ("GameController").GetComponent<VirtualJoystick> ();
		mouseControl = GameObject.FindGameObjectWithTag ("MouseArea").GetComponent<MouseController> ();
		fire = GameObject.FindGameObjectWithTag ("FireButton").GetComponent<UIbuttons> ();
		reload = GameManagers.Instance.ReloadButton;
	}

	void Update(){
		if (!GameManagers.Instance.GameState.IsPaused()) {
			//Vertical = Input.GetAxis ("Vertical");
			//Horizontal = Input.GetAxis ("Horizontal");
			Vertical = joystick.InputDirection.z;
			Horizontal = joystick.InputDirection.x;
			MouseInput = new Vector2 (mouseControl.TouchDist.x, mouseControl.TouchDist.y);
			//MouseInput=new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y"));
			//Debug.Log (Input.GetAxisRaw("Mouse X"));

			Fire1 = fire.GetKeyDown ();
			Reload = reload.GetKeyDown ();
		}
	}

}
