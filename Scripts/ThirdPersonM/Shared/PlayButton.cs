using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
	MainScreenAudioController scream;
	Animator animator;
	float counter,playCount;
	bool played;
	TMP_Text highscore;



	// Use this for initialization
	void Start ()
	{
		scream = GetComponent<MainScreenAudioController> ();
		animator=GetComponent<Animator> ();
		playCount = 0;
		counter = 0;
		played = false;
		highscore = GameObject.FindGameObjectWithTag ("highscoretext").GetComponent<TMP_Text> ();
		highscore.text = "Best : "+ PlayerPrefs.GetInt ("HighScore",0).ToString();
		PlayerPrefs.SetInt ("AudioON", 1);
		GameObject.FindGameObjectWithTag ("AudioOFF").GetComponent<Image> ().enabled = false;
		GameObject.FindGameObjectWithTag ("AudioOFF").GetComponent<Button> ().enabled = false;

	}
	
	// Update is called once per frame
	void Update ()
	{
		counter += Time.deltaTime;
		if (counter >5)
			Scream ();



	}

	public void playButton(){
		SceneManager.LoadScene (1);
		/*animator.SetBool ("isScreaming", true);
		scream.Play ();*/

	}

	public void ExitGame(){
		Application.Quit ();
	}

	private void Scream(){
		animator.SetBool ("isScreaming", true);
		scream.Play ();
		counter = 0;
		played = true;
		animator.SetBool ("isScreaming", false);
	}

	public void ToggleAudioON(){
		if (PlayerPrefs.GetInt ("AudioON") == 1) {
			PlayerPrefs.SetInt ("AudioON", 0);
			GameObject.FindGameObjectWithTag ("AudioOFF").GetComponent<Image> ().enabled = true;
			GameObject.FindGameObjectWithTag ("AudioOFF").GetComponent<Button> ().enabled = true;
			GameObject.FindGameObjectWithTag ("AudioON").GetComponent<Image> ().enabled = false;
			GameObject.FindGameObjectWithTag ("AudioON").GetComponent<Button> ().enabled = false;

			//Stopping AUDIO
			AudioSource[] sources=Camera.main.GetComponents<AudioSource>();
			foreach (AudioSource source in sources)
				source.enabled = false;

			scream.Stop ();
		} else if (PlayerPrefs.GetInt ("AudioON") == 0) {
			PlayerPrefs.SetInt ("AudioON", 1);
			GameObject.FindGameObjectWithTag ("AudioOFF").GetComponent<Image> ().enabled = false;
			GameObject.FindGameObjectWithTag ("AudioOFF").GetComponent<Button> ().enabled = false;
			GameObject.FindGameObjectWithTag ("AudioON").GetComponent<Image> ().enabled = true;
			GameObject.FindGameObjectWithTag ("AudioON").GetComponent<Button> ().enabled = true;

			AudioSource[] sources=Camera.main.GetComponents<AudioSource>();
			foreach (AudioSource source in sources)
				source.enabled = true;
		}
	}

	public void RateGame(){
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.redwings.projektmillensnial");
	}

}

