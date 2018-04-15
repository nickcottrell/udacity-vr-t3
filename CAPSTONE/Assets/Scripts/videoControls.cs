using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoControls : MonoBehaviour {

	private gameLogic m_gameLogic;

	public GameObject m_vid01;
	public GameObject m_vid02;
	public GameObject m_vid03;
	public GameObject m_vid04;
	public GameObject m_vid05;


	void Awake() {
		m_gameLogic = GameObject.FindObjectOfType<gameLogic>();
	}

	void Start(){
		if (gameLogic.m_levelTwoUlocked == false) {
			m_vid01.SetActive (true);
		} 

		if (gameLogic.m_levelTwoUlocked == true) {
			ResetVideos ();
			m_vid02.SetActive (true);
		}

		if (gameLogic.m_levelThreeUlocked == true) {
			ResetVideos ();
			m_vid03.SetActive (true);
		}

		if (gameLogic.m_gameIsWon == true && gameLogic.m_playerScore < 5000) {
			ResetVideos ();
			m_vid04.SetActive (true);
		}
		if (gameLogic.m_gameIsWon == true && gameLogic.m_playerScore > 5000) {
			ResetVideos ();
			m_vid05.SetActive (true);
		}
	}

	void ResetVideos () {
		m_vid01.SetActive (false);
		m_vid02.SetActive (false);
		m_vid03.SetActive (false);
		m_vid04.SetActive (false);
		m_vid05.SetActive (false);
	}
}
