using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class HealthBarScript : MonoBehaviour
{

	public RectTransform healthbarTransform;
	private float cachedY;
	private float minXvalue, maxXValue;
	private TMP_Text text;
	public Image healthImage;


	// Use this for initialization
	void Start ()
	{
		healthbarTransform = GetComponent<RectTransform> ();
		healthImage = GetComponent<Image> ();
		cachedY = healthbarTransform.position.y;
		minXvalue = healthbarTransform.position.x - healthbarTransform.rect.width;
		Debug.Log (healthbarTransform.position);
		maxXValue = healthbarTransform.position.x;
		text = GameObject.FindGameObjectWithTag ("healthtext").GetComponent<TMP_Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		text.text = "Health: "+ GameManagers.Instance.LocalPlayer.playerHealth.ToString ();

		/*float currentXvalue = MapValues (GameManagers.Instance.LocalPlayer.playerHealth, 0, 100,minXvalue, maxXValue);
		healthbarTransform.position = new Vector3 (currentXvalue, cachedY,0);*/

		healthImage.fillAmount = GameManagers.Instance.LocalPlayer.playerHealth / 100;

		if (GameManagers.Instance.LocalPlayer.playerHealth > 50) {
			healthImage.color = new Color32 ((byte)MapValues (GameManagers.Instance.LocalPlayer.playerHealth, 100 / 2, 100, 255, 0), 255, 0, 255);
		} else {
			healthImage.color = new Color32 (255,(byte)MapValues (GameManagers.Instance.LocalPlayer.playerHealth, 0, 100/2, 0, 255), 0, 255);
		}
	}

	public void TakenDamage(){
		
	}

	private float MapValues(float x,float inMin,float inMax,float outMin,float outMax){
		return (x - inMin)* (outMax - outMin) / (inMax - inMin) +outMax;
	}
}

