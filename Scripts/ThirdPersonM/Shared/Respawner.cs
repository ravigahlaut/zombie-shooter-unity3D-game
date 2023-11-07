using UnityEngine;
using System.Collections;

public class Respawner : MonoBehaviour
{
	public int z=1;

	public void Despawn(GameObject go, float inSeconds){
		
		/*GameManagers.Instance.Timer.Add (() => {
			Instantiate(zombie);
		}, inSeconds);*/
		Destroy (go, 5);
		z--;

	}

	public void Spawn(int wave, GameObject zombie){
		int i = wave * 2;
		this.z = i;
		for(int j=0;j<=i;j++){
			Instantiate (zombie,GameObject.FindGameObjectWithTag("EditorOnly").transform.parent);
		}
	}


}

