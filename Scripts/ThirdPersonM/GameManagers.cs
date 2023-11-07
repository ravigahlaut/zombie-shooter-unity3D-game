using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers  {

	public event System.Action<Player> OnLocalPlayerJoined;

	private GameObject gameObject;

	private static GameManagers m_Instance;
	public static GameManagers Instance {
		
		get{
			if (m_Instance == null) {
				m_Instance = new GameManagers ();
				m_Instance.gameObject = new GameObject ("_gameManagers");
				m_Instance.gameObject.AddComponent<InputMan> ();
				m_Instance.gameObject.AddComponent<Timer> ();
				m_Instance.gameObject.AddComponent<Respawner> ();
				m_Instance.gameObject.AddComponent<WaveManager> ();
				m_Instance.gameObject.AddComponent<KillScore> ();
				m_Instance.gameObject.AddComponent<GameState> ();

			}
			return m_Instance;
		}
		
		
	}

	private InputMan inputMan;
	public InputMan InputMan {
		get{
			if (inputMan == null) {
				
				inputMan = gameObject.GetComponent<InputMan> ();
				if(inputMan!=null)Debug.Log ("inputman Created");
			}
			return inputMan;
		}
	}

	private WaveManager m_WaveManager;
	public WaveManager WaveManager{
		get{ 
			if (m_WaveManager == null) {
				m_WaveManager = gameObject.GetComponent<WaveManager> ();
			}
			return m_WaveManager;
		}
	}

	private Timer m_Timer;
	public Timer Timer {
		get{ 
			if (m_Timer == null)
				m_Timer = gameObject.GetComponent<Timer> ();
			return m_Timer;
			}
	}

	private Respawner m_Respawner;
	public Respawner Respawner{
		get{ 
			if (m_Respawner == null) {
				m_Respawner = gameObject.GetComponent<Respawner> ();
			}
			return m_Respawner;
		}
	}

	private Player m_LocalPlayer;
	public Player LocalPlayer {
		get{ 
			return m_LocalPlayer;
		}
		set{ 
			m_LocalPlayer = value;
			if (OnLocalPlayerJoined != null) {
				OnLocalPlayerJoined (m_LocalPlayer);
			}
		}
	}

	private BloodCanvasEffect m_bloodCanvas;
	public BloodCanvasEffect BloodCanvasEffect{
		get{ 
			if (m_bloodCanvas == null) {
				m_bloodCanvas = GameObject.FindGameObjectWithTag ("bloodCanvas").GetComponent<BloodCanvasEffect>();
			}
			return m_bloodCanvas;
		}
	}

	private WeaponReloader m_reloader;
	public WeaponReloader WeaponReloader{
		get{ 
			if (m_reloader == null) {
				m_reloader = GameObject.FindGameObjectWithTag ("Weapon").GetComponentInChildren<WeaponReloader> ();
			}
			return m_reloader;
		}
	}

	private KillScore m_score;
	public KillScore KillScore{
		get{ 
			if (m_score == null) {
				m_score = gameObject.GetComponent<KillScore> ();
			}
			return m_score;
		}
	}
	private GameState m_gameState;
	public GameState GameState{
		get{ 
			if (m_gameState == null) {
				m_gameState = gameObject.GetComponent<GameState> ();
			}
			return m_gameState;
		}
	}
	private ReloadButton m_reloadButton;
	public ReloadButton ReloadButton{
		get{ 
			if (m_reloadButton == null) {
				m_reloadButton = GameObject.FindGameObjectWithTag ("reloadButton").GetComponentInChildren<ReloadButton> ();
			}
			return m_reloadButton;
		}
	}
	private HealthBarScript m_healthBar;
	public HealthBarScript HealthBarScript{
		get{ 
			if (m_healthBar == null) {
				m_healthBar = GameObject.FindGameObjectWithTag ("HealthBarScript").GetComponentInChildren<HealthBarScript> ();
			}
			return m_healthBar;
		}
	}


}


