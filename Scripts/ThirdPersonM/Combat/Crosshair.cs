using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{

	[SerializeField]Texture2D image;
	[SerializeField]int size;
	[SerializeField]float maxAngle;
	[SerializeField] float minAngle;

	public Vector3 ScreenPosition;

	public float lookHeight;

	public void LookHeight(float value){
		lookHeight += value;

		if (lookHeight > maxAngle || lookHeight < minAngle)
			lookHeight -= value;
	}


	void OnGUI(){
		Vector3 screenPosition = Camera.main.WorldToScreenPoint (transform.position);

		screenPosition.y = Screen.height - screenPosition.y;
		ScreenPosition = screenPosition;
		GUI.DrawTexture(new Rect((screenPosition.x-size/2),screenPosition.y-size/2,size,size),image);

	}




}

