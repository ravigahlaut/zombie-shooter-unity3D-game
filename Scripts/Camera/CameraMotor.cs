using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

	public Transform target;
	public Vector3 offset;

	private float smoothFactor=0.3f;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		//offset = new Vector3 (0f, 2.0f, -3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		
		Vector3 desiredPos = target.position + offset;
		Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos, smoothFactor);
		transform.position = smoothedPos;

		//transform.LookAt (target);
	}
}
