using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour
{

	bool isPaused;
	bool isGameOver;
	bool isPlaying;

	// Use this for initialization
	void Start ()
	{
		isPlaying = true;
		GameObject.FindGameObjectWithTag ("PauseMenu").GetComponent<Canvas> ().enabled = false;
		GameObject.FindGameObjectWithTag ("gameovercanvas").GetComponent<Canvas> ().enabled = false;

	}
	
	public bool IsPaused(){
		return isPaused;
	}

	public void SetPause(bool value){
		isPaused = value;
		if (value) {
			isPlaying = false;
			GameObject.FindGameObjectWithTag ("PauseMenu").GetComponent<Canvas> ().enabled = true;
		} else {
			isPlaying = true;
			GameObject.FindGameObjectWithTag ("PauseMenu").GetComponent<Canvas> ().enabled = false;
		}
	}

	public void SetGameOver(bool value){
		isGameOver = value;
		if (value) {
			isPlaying = false;
			GameObject.FindGameObjectWithTag ("gameovercanvas").GetComponent<Canvas> ().enabled = true;

		} else {
			isPlaying = true;
			GameObject.FindGameObjectWithTag ("gameovercanvas").GetComponent<Canvas> ().enabled = false;

		}
	}

	public bool IsGameOver(){
		return isGameOver;
	}
}

