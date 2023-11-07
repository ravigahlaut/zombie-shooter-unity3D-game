using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIbuttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private Image fireButton;

	private string KeyCode;
	private bool isPressed;

	// Use this for initialization
	void Start () {
		fireButton = GetComponent<Image> ();
	}
	
	public virtual void OnPointerDown(PointerEventData ped){
		if (!GameManagers.Instance.GameState.IsPaused()) {
			Vector2 pos = Vector2.zero;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle (fireButton.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
				KeyCode = "Fire1";

				isPressed = true;
			}
		}

	}
	public virtual void OnPointerUp(PointerEventData ped){
		
		KeyCode = "nothing";
		isPressed = false;

	}


	public bool GetKeyDown(){
		return isPressed;
	}
}
