using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartboostSDK;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour {

	[System.Serializable]
	public class MouseInput {
		public Vector2 Damping;
		public Vector2 Senstivity;
	}

	[SerializeField]float speed;
	[SerializeField]MouseInput MouseControl;
	[SerializeField]float PlayerHitPoints;
	[SerializeField]AudioController footsteps;
	[SerializeField]float minimumMoveThreshold;
	public float playerHealth;
	public bool playerDead = false;
	public GameObject[] zombie;
	[SerializeField] ParticleSystem blood;

	InputMan playerInput;
	Vector2 mouseInput;
	public List<string> delegateHistory;
	Vector3 lastFramePos;

	public PlayerAim playeraim;


	private MoveController moveController;
	public MoveController MoveController {
		get{ 
			if (moveController == null) {
				moveController = GetComponent<MoveController> ();
			}
			return moveController;
		}
	}

	private Crosshair m_Crosshair;
	private Crosshair Crosshair{
		get{ 
			if (m_Crosshair == null) {
				m_Crosshair = GetComponentInChildren<Crosshair> ();
			}
			return m_Crosshair;
		}
	}

	// Use this for initialization
	void Awake () {
		playerInput = GameManagers.Instance.InputMan;
		GameManagers.Instance.LocalPlayer = this;
		Instantiate (zombie[Random.Range(0,zombie.Length)]);
		playerHealth = PlayerHitPoints;

	}
	void Start(){
		SetupDelegates ();
		Chartboost.setAutoCacheAds(true);

		Chartboost.setPIDataUseConsent(CBPIDataUseConsent.YesBehavioral);

		Chartboost.cacheInterstitial (CBLocation.Default);
		CheckSound ();

	}

	private void CheckSound(){
		if (PlayerPrefs.GetInt ("AudioON", 1) == 0) {
			AudioSource[] sources=Camera.main.GetComponents<AudioSource>();
			foreach (AudioSource source in sources)
				source.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!playerDead && !GameManagers.Instance.GameState.IsPaused()) {
			if (playerInput == null)
				Debug.Log ("PlayerInput is null");
			Vector2 direction = new Vector2 (playerInput.Vertical * speed, playerInput.Horizontal * speed);


		
			MoveController.Move (direction);

			if (Vector3.Distance (transform.position, lastFramePos) > minimumMoveThreshold) {
				footsteps.Play ();
			}

			mouseInput.x = Mathf.Lerp (mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
			mouseInput.y = Mathf.Lerp (mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);


			transform.Rotate (Vector3.up * mouseInput.x * MouseControl.Senstivity.x * Time.deltaTime);

			Crosshair.LookHeight (mouseInput.y * MouseControl.Senstivity.y * Time.deltaTime);
			playeraim.SetRotation (mouseInput.y * MouseControl.Senstivity.y*Time.deltaTime);

			lastFramePos = transform.position;
			GameManagers.Instance.InputMan.mouseControl.TouchDist = Vector3.zero;
		} 

	}

	public void TakeDamage(float amount){
		if (!GameManagers.Instance.GameState.IsPaused ()) {
			if (!playerDead) {
				playerHealth -= amount;
				//Instantiate (blood, transform);
				blood.Play ();
				GameManagers.Instance.KillScore.ResetMultiplier ();
				if (playerHealth < 0) {
					playerHealth = 0;
				}
				if (playerHealth == 0) {
					playerDead = true;
					Chartboost.showInterstitial (CBLocation.Default);
					GameManagers.Instance.GameState.SetGameOver (true);
				}
			}
		}
	}

	void SetupDelegates()
	{
		// Listen to all impression-related events
		Chartboost.didFailToLoadInterstitial += didFailToLoadInterstitial;
		Chartboost.didDismissInterstitial += didDismissInterstitial;
		Chartboost.didCloseInterstitial += didCloseInterstitial;
		Chartboost.didClickInterstitial += didClickInterstitial;
		Chartboost.didCacheInterstitial += didCacheInterstitial;
		Chartboost.shouldDisplayInterstitial += shouldDisplayInterstitial;
		Chartboost.didDisplayInterstitial += didDisplayInterstitial;
		Chartboost.didFailToRecordClick += didFailToRecordClick;
		Chartboost.didFailToLoadRewardedVideo += didFailToLoadRewardedVideo;
		Chartboost.didDismissRewardedVideo += didDismissRewardedVideo;
		Chartboost.didCloseRewardedVideo += didCloseRewardedVideo;
		Chartboost.didClickRewardedVideo += didClickRewardedVideo;
		Chartboost.didCacheRewardedVideo += didCacheRewardedVideo;
		Chartboost.shouldDisplayRewardedVideo += shouldDisplayRewardedVideo;
		Chartboost.didCompleteRewardedVideo += didCompleteRewardedVideo;
		Chartboost.didDisplayRewardedVideo += didDisplayRewardedVideo;
		Chartboost.didPauseClickForConfirmation += didPauseClickForConfirmation;
		Chartboost.willDisplayVideo += willDisplayVideo;
		#if UNITY_IPHONE
		Chartboost.didCompleteAppStoreSheetFlow += didCompleteAppStoreSheetFlow;
		#endif
	}
	void didFailToLoadInterstitial(CBLocation location, CBImpressionError error) {
		Debug.Log(string.Format("didFailToLoadInterstitial: {0} at location: {1}", error, location));
	}

	void didDismissInterstitial(CBLocation location) {
		Debug.Log("didDismissInterstitial: " + location);
	}

	void didCloseInterstitial(CBLocation location) {
		Debug.Log("didCloseInterstitial: " + location);
	}

	void didClickInterstitial(CBLocation location) {
		Debug.Log("didClickInterstitial: " + location);
	}

	void didCacheInterstitial(CBLocation location) {
		Debug.Log("didCacheInterstitial: " + location);
	}

	bool shouldDisplayInterstitial(CBLocation location) {
		Debug.Log("shouldDisplayInterstitial: " + location);
		return true;
	}

	void didDisplayInterstitial(CBLocation location){
		Debug.Log("didDisplayInterstitial: " + location);
	}

	void didFailToLoadMoreApps(CBLocation location, CBImpressionError error) {
		Debug.Log(string.Format("didFailToLoadMoreApps: {0} at location: {1}", error, location));
	}

	void didDismissMoreApps(CBLocation location) {
		Debug.Log(string.Format("didDismissMoreApps at location: {0}", location));
	}

	void didCloseMoreApps(CBLocation location) {
		Debug.Log(string.Format("didCloseMoreApps at location: {0}", location));
	}

	void didClickMoreApps(CBLocation location) {
		Debug.Log(string.Format("didClickMoreApps at location: {0}", location));
	}

	void didCacheMoreApps(CBLocation location) {
		Debug.Log(string.Format("didCacheMoreApps at location: {0}", location));
	}

	bool shouldDisplayMoreApps(CBLocation location) {
		Debug.Log(string.Format("shouldDisplayMoreApps at location: {0}", location));
		return true;
	}

	void didDisplayMoreApps(CBLocation location){
		Debug.Log("didDisplayMoreApps: " + location);
	}

	void didFailToRecordClick(CBLocation location, CBClickError error) {
		Debug.Log(string.Format("didFailToRecordClick: {0} at location {1}", error, location));
	}

	void didFailToLoadRewardedVideo(CBLocation location, CBImpressionError error) {
		Debug.Log(string.Format("didFailToLoadRewardedVideo: {0} at location {1}", error, location));
	}

	void didDismissRewardedVideo(CBLocation location) {
		Debug.Log("didDismissRewardedVideo: " + location);
	}

	void didCloseRewardedVideo(CBLocation location) {
		Debug.Log("didCloseRewardedVideo: " + location);
	}

	void didClickRewardedVideo(CBLocation location) {
		Debug.Log("didClickRewardedVideo: " + location);
	}

	void didCacheRewardedVideo(CBLocation location) {
		Debug.Log("didCacheRewardedVideo: " + location);
	}

	bool shouldDisplayRewardedVideo(CBLocation location) {
		Debug.Log("shouldDisplayRewardedVideo: " + location);
		return true;
	}

	void didCompleteRewardedVideo(CBLocation location, int reward) {
		Debug.Log(string.Format("didCompleteRewardedVideo: reward {0} at location {1}", reward, location));
	}

	void didDisplayRewardedVideo(CBLocation location){
		Debug.Log("didDisplayRewardedVideo: " + location);
	}

	void didCacheInPlay(CBLocation location) {
		Debug.Log("didCacheInPlay called: "+location);
	}

	void didFailToLoadInPlay(CBLocation location, CBImpressionError error) {
		Debug.Log(string.Format("didFailToLoadInPlay: {0} at location: {1}", error, location));
	}

	void didPauseClickForConfirmation() {
		Debug.Log("didPauseClickForConfirmation called");
	}

	void willDisplayVideo(CBLocation location) {
		Debug.Log("willDisplayVideo: " + location);
	}

	#if UNITY_IPHONE
	void didCompleteAppStoreSheetFlow() {
	Debug.Log("didCompleteAppStoreSheetFlow");
	}
	#endif

	void AddLog(string text)
	{
		Debug.Log(text);
		delegateHistory.Insert(0, text + "\n");
		int count = delegateHistory.Count;
		if( count > 20 )
		{
			delegateHistory.RemoveRange(20, count-20);
		}
	}
	void OnDisable() {
		// Remove event handlers
		Chartboost.didFailToLoadInterstitial -= didFailToLoadInterstitial;
		Chartboost.didDismissInterstitial -= didDismissInterstitial;
		Chartboost.didCloseInterstitial -= didCloseInterstitial;
		Chartboost.didClickInterstitial -= didClickInterstitial;
		Chartboost.didCacheInterstitial -= didCacheInterstitial;
		Chartboost.shouldDisplayInterstitial -= shouldDisplayInterstitial;
		Chartboost.didDisplayInterstitial -= didDisplayInterstitial;
		Chartboost.didFailToRecordClick -= didFailToRecordClick;
		Chartboost.didFailToLoadRewardedVideo -= didFailToLoadRewardedVideo;
		Chartboost.didDismissRewardedVideo -= didDismissRewardedVideo;
		Chartboost.didCloseRewardedVideo -= didCloseRewardedVideo;
		Chartboost.didClickRewardedVideo -= didClickRewardedVideo;
		Chartboost.didCacheRewardedVideo -= didCacheRewardedVideo;
		Chartboost.shouldDisplayRewardedVideo -= shouldDisplayRewardedVideo;
		Chartboost.didCompleteRewardedVideo -= didCompleteRewardedVideo;
		Chartboost.didDisplayRewardedVideo -= didDisplayRewardedVideo;
		Chartboost.didPauseClickForConfirmation -= didPauseClickForConfirmation;
		Chartboost.willDisplayVideo -= willDisplayVideo;
		#if UNITY_IPHONE
		Chartboost.didCompleteAppStoreSheetFlow -= didCompleteAppStoreSheetFlow;
		#endif
	}

}
