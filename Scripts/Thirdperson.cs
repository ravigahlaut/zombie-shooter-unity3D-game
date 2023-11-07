using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thirdperson : MonoBehaviour {

	public float speed=5;
	public VirtualJoystick joystick;


	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();


	}
	
	void PlayerMovement(){
		
		transform.position +=joystick.InputDirection*speed*Time.deltaTime;
		if (joystick.InputDirection != Vector3.zero) {
			animator.SetBool ("isrunning", true);
		}
			

	}

	void Update(){
		PlayerMovement ();
	}


}
