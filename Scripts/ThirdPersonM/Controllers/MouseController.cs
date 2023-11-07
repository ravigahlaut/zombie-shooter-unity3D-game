using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour, IPointerUpHandler,IPointerDownHandler,IDragHandler
{
	[HideInInspector]public Vector2 TouchDist;
	private Vector2 PointerOld;
	[HideInInspector]protected int PointerId;
	[HideInInspector]public bool Pressed;






	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad (this);
	}

	public void OnDrag(PointerEventData ped){
		if (!GameManagers.Instance.GameState.IsPaused()) {
			/*if (Pressed) {
			if (PointerId >= 0 && PointerId < Input.touches.Length) {
				TouchDist = (Input.touches [PointerId].position - PointerOld)*Time.deltaTime;

					PointerOld = Input.touches [PointerId].position;

			} else {
				TouchDist = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
				PointerOld = Input.mousePosition;
			}
		} else {
			TouchDist = Vector2.zero;
		}*/
			if (Pressed) {
				TouchDist = ped.position - PointerOld;
				PointerOld = ped.position;
			} else {
				TouchDist = Vector2.zero;
			}
		}
	}

	public void OnPointerDown(PointerEventData ped){
		if (!GameManagers.Instance.GameState.IsPaused()) {
			Pressed = true;
			PointerId = ped.pointerId;
			PointerOld = ped.position;
		}
	}

	public void OnPointerUp(PointerEventData ped){
		
			Pressed = false;
			Debug.Log ("Now Pressed is false");
			TouchDist = Vector2.zero;
		
	}
	

}

