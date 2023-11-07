using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class AmmoCountUI : MonoBehaviour
{

	TMP_Text ammoText;
	WeaponReloader reloader;

	// Use this for initialization
	void Start ()
	{
		ammoText = GetComponent<TMP_Text> ();
		reloader = GameManagers.Instance.WeaponReloader;
	}
	
	// Update is called once per frame
	void Update ()
	{
		ammoText.text = reloader.RoundsRemainingInClip + " / " + reloader.GetMaxAmmo;
	}
}

