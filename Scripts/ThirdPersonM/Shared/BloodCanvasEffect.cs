using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BloodCanvasEffect : MonoBehaviour
{

	CanvasRenderer image;

	// Use this for initialization
	void Start ()
	{
		image = GetComponent<CanvasRenderer> ();
		image.SetAlpha (0.0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void CreateEffect(){
		image.SetAlpha (1.0f);
	}



	public void RemoveEffect(){
		image.SetAlpha (0.0f);
	}

	public void KillEffect(){
		CreateEffect ();
		GameManagers.Instance.Timer.Add (RemoveEffect, 0.3f);
	}

}