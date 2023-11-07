using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;


public class KillScore : MonoBehaviour
{

	int killCount;
	int scoreMultiplier;
	int score;
	Text scoreText;
	TMP_Text text;
	int prevHigh;

	// Use this for initialization
	void Start ()
	{
		killCount = 0;
		scoreMultiplier = 1;
		score = 0;
		text = GameObject.FindGameObjectWithTag ("scoretext").GetComponent<TMP_Text>();
		prevHigh = PlayerPrefs.GetInt ("HighScore", 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		text.text = "Score: " +GetScore();
		if (GetScore () > prevHigh) {
			PlayerPrefs.SetInt ("HighScore", GetScore ());
		}
	}

	public void OneMoreKilled(){
		killCount++;
		SetScore ();
		scoreMultiplier++;
	}

	private void SetScore(){
		score +=  scoreMultiplier;
	}

	public int GetScore(){
		
		return score;
	}

	public void ResetMultiplier(){
		scoreMultiplier = 1;
	}
}

