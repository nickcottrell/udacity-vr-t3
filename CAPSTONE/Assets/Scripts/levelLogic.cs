using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class levelLogic : MonoBehaviour {


	private gameLogic m_gameLogic;

	public float m_timeLeft = 60.0f;
	public bool m_gameIsActive = true;
	private TextMeshProUGUI m_gameTimerText;
	private GameObject m_gameTimer;
	public bool m_showStartMsg = false;
	public string m_startMsg = null;
	public int m_startMsgSeconds;


	void Awake() {
		m_gameLogic = GameObject.FindObjectOfType<gameLogic>();
	}

	void Start () {
		m_gameTimer = GameObject.Find ("Player/GvrEditorEmulator/HUD-parent/HUD/timer");
		m_gameTimerText = GameObject.Find("Player/GvrEditorEmulator/HUD-parent/HUD/timer/Panel/timer").GetComponent<TextMeshProUGUI>();
		if (m_showStartMsg == true) {
			m_gameLogic.DisplayNotif (m_startMsg, m_startMsgSeconds);
		}
	}
	
	// Update is called once per frame
	void Update () {

		m_timeLeft -= Time.deltaTime;

		if (m_timeLeft > 0 & m_gameIsActive == true & gameLogic.m_gameIsWon == false) {
			m_gameTimer.SetActive (true);
			m_gameTimerText.SetText (m_timeLeft.ToString ("F0"));
		} else if (m_timeLeft < 0 & m_gameIsActive == true & gameLogic.m_gameIsWon == false) {
			m_gameIsActive = false;
			m_gameLogic.EndGame ();
		} else if (m_timeLeft > 0 & gameLogic.m_gameIsWon == true) {
			m_gameIsActive = false;
			m_gameTimer.SetActive (false);
		} else if (m_gameIsActive == false) {
			//do nothing
		}
	}

}
