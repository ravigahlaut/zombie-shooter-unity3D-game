using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
	[SerializeField]Vector3 cameraOffset;
	[SerializeField]float damping;

	Transform cameraLookTarget;
	Player localPlayer;

	void Awake(){
		GameManagers.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
	}

	void HandleOnLocalPlayerJoined(Player player){
		localPlayer = player;
		cameraLookTarget = localPlayer.transform.Find ("cameraLookTarget");

		if (cameraLookTarget == null)
			cameraLookTarget = localPlayer.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 targetPosition = cameraLookTarget.position + localPlayer.transform.forward * cameraOffset.z +
		                         localPlayer.transform.up * cameraOffset.y +
		                         localPlayer.transform.right * cameraOffset.x;
		Quaternion targetRotation = Quaternion.LookRotation (cameraLookTarget.position - targetPosition, Vector2.up);


		Vector3 collisionDetected = cameraLookTarget.position + localPlayer.transform.up;
		RaycastHit hit;
		if (Physics.Linecast (collisionDetected, targetPosition, out hit)) {
			Vector3 hitPoint = new Vector3 (hit.point.x + hit.normal.x * 0.2f, hit.point.y, hit.point.z + hit.normal.z * .2f);
			targetPosition = new Vector3 (hitPoint.x, targetPosition.y, hitPoint.z);
		}

		transform.position = Vector3.Lerp (transform.position, targetPosition, damping * Time.deltaTime);
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, damping * Time.deltaTime);


	}
}

