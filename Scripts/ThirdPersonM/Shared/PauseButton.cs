using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseButton : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{

	private Image pauseButton;
	private string KeyCode;
	private bool isPressed;

	// Use this for initialization
	void Start () {
		pauseButton = GetComponent<Image> ();
	}

	public virtual void OnPointerDown(PointerEventData ped){
		
			Vector2 pos = Vector2.zero;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle (pauseButton.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
				SetPause ();
			}


	}
	public virtual void OnPointerUp(PointerEventData ped){

		KeyCode = "nothing";
		isPressed = false;

	}


	public bool GetKeyDown(){
		return isPressed;
	}

	public void SetPause(){
		Debug.Log ("SetPause called");
		if (!GameManagers.Instance.GameState.IsPaused ()) {
			Time.timeScale = 0;
			Debug.Log (Time.timeScale);
			GameManagers.Instance.GameState.SetPause(true);
		} else {
			Time.timeScale = 1.0f;
			GameManagers.Instance.GameState.SetPause(false);
		}
	}

	public void Exit(){
		SceneManager.LoadScene (0);
	}
}

