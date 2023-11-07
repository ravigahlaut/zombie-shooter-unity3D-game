using UnityEngine;
using System.Collections;

public class WeaponReloader : MonoBehaviour
{

	[SerializeField]int maxAmmo;
	[SerializeField]float reloadTime;
	[SerializeField]int clipSize;

	int ammo;
	public int shotsFiredInClip;
	bool isReloading;

	public int RoundsRemainingInClip {
		get { 
			return clipSize - shotsFiredInClip;
		}
	}
	public int GetMaxAmmo{
		get{ 
		
			return maxAmmo;
			}
	}

	public bool IsReloading {
		get{ 
			return isReloading;
		}
	}

	public void Reload(){
		if (isReloading)
			return;

		isReloading = true;
		print ("Reloading started");
		GameManagers.Instance.ReloadButton.SetButtonAlpha (0.3f);
		GameManagers.Instance.Timer.Add (ExecuteReload, reloadTime);
	}

	private void ExecuteReload() {
		print ("Reloading executed");
		GameManagers.Instance.ReloadButton.SetButtonAlpha (1.0f);
		isReloading = false;
		ammo -= shotsFiredInClip;
		shotsFiredInClip = 0;

		if (ammo < 0) {
			ammo = 0;
			shotsFiredInClip += -ammo;
		}
	}

	public void TakeFromClip(int amount){
		shotsFiredInClip += amount;
	}




}

