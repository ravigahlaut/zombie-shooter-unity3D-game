using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReloadButton : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{

	private Image fireButton;
	private string KeyCode;
	private bool isPressed;
	private CanvasRenderer canvas;

	// Use this for initialization
	void Start () {
		fireButton = GetComponent<Image> ();
		canvas = GetComponent<CanvasRenderer> ();
	}

	public virtual void OnPointerDown(PointerEventData ped){
		if (!GameManagers.Instance.GameState.IsPaused()) {
			Vector2 pos = Vector2.zero;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle (fireButton.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
				KeyCode = "R";

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

	public void SetButtonAlpha(float value){
		canvas.SetAlpha (value);
	}
}

