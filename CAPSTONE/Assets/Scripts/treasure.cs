using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasure : MonoBehaviour {

	private gameLogic m_gameLogic;
	public GameObject m_SoundDoor;
	public GameObject m_Door;
	private Animator m_AnimDoorOpen;
	public GameObject m_LevelMusic;
	public GameObject m_WinMusic;


	void Awake() {
		m_gameLogic = GameObject.FindObjectOfType<gameLogic>();
		m_AnimDoorOpen = m_Door.GetComponent<Animator> ();
	}

	public void OpenTreasure() {
		if (gameLogic.m_finalKey == true) {

			m_AnimDoorOpen.enabled = true;
			m_SoundDoor.SetActive (true);
			m_LevelMusic.SetActive (false);
			m_WinMusic.SetActive (true);
			m_gameLogic.WinGame ();
		
		} else {
			m_gameLogic.DisplayNotif ("You need the final key. Find it hidden somewhere!", 3);

		}
	}	
}
