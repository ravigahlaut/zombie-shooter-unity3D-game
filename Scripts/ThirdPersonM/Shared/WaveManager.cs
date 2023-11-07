using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{

	public int currentWave;
	int enemiesLeft=1;
	int maxWave=10;

	GameObject[] zombiePrefabs;

	// Use this for initialization
	void Start ()
	{
		currentWave = 0;
		zombiePrefabs = GameManagers.Instance.LocalPlayer.GetComponent<Player> ().zombie;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (enemiesLeft == 0) {
			
		}
	}

	public void AnEnemyIsDead(){
		if (enemiesLeft != 0) {
			enemiesLeft--;
		}
		if (enemiesLeft == 0) {
			Debug.Log ("All Enemies Are Dead");
			if (currentWave<maxWave) {
				currentWave++;

			}
			enemiesLeft = currentWave * 2;
			GameManagers.Instance.Timer.Add (SpawnNextWave, 5);
		}
	}

	public void SpawnNextWave(){
		
		for (int j = 0; j <enemiesLeft; j++) {
			Instantiate (zombiePrefabs [Random.Range (0, zombiePrefabs.Length)]);
		}
	}
}

