﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IDragHandler,IPointerUpHandler,IPointerDownHandler {

	private Image bgImage;
	private Image joyStickImage;

	public Vector3 InputDirection{ set; get; }

	// Use this for initialization
	void Start () {
		bgImage = GetComponent<Image> ();
		joyStickImage = transform.GetChild(0).GetComponent<Image> ();
	}
	
	public virtual void OnDrag(PointerEventData ped){
		if (!GameManagers.Instance.GameState.IsPaused()) {
			Vector2 pos = Vector2.zero;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImage.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
				pos.x = (pos.x / bgImage.rectTransform.sizeDelta.x);
				pos.y = (pos.y / bgImage.rectTransform.sizeDelta.y);

				float x = (bgImage.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
				float y = (bgImage.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

				InputDirection = new Vector3 (x, 0, y);

				InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

				joyStickImage.rectTransform.anchoredPosition = new Vector3 (InputDirection.x * (bgImage.rectTransform.sizeDelta.x / 3), InputDirection.z * (bgImage.rectTransform.sizeDelta.y / 3));
			}
		}
	}
	public virtual void OnPointerUp(PointerEventData ped){

		InputDirection = Vector3.zero;
		joyStickImage.rectTransform.anchoredPosition = Vector3.zero;
		
	}
	public virtual void OnPointerDown(PointerEventData ped){

		OnDrag (ped);

	}
}
