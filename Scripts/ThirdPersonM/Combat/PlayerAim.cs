using UnityEngine;
using System.Collections;

public class PlayerAim : MonoBehaviour
{

	public void SetRotation(float amount){
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x - amount, transform.eulerAngles.y, transform.eulerAngles.z);
	}

	public float getAngle(){
		return checkAngle (transform.eulerAngles.x);
	}

	public float checkAngle(float value){
		float angle = value - 180;

		if (angle > 0)
			return angle - 180;

		return angle + 180;
	}

	void Update(){
		print (getAngle ());
	}
}

