using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameLogic : MonoBehaviour {

	public static bool m_levelTwoUlocked = false;
	public static bool m_levelThreeUlocked = false;
	public static int m_playerScore = 0;
	public static bool m_finalKey = false;
	public static bool m_gameIsWon = false;

	private string m_levelTwoKeyScore = "Locked";
	private string m_levelThreeKeyScore = "Locked";
	private GameObject m_gameOver;
	private TextMeshProUGUI m_tmp_score;
	private TextMeshProUGUI m_tmp_leveltwokey;
	private TextMeshProUGUI m_tmp_levelthreekey;
	private TextMeshProUGUI m_tmp_notif;
	private TextMeshProUGUI m_tmp_playerhelp = null;

	private bool m_highScoreShown = false;
	private int m_highestScore = 5200;

	private GameObject m_vid01;
	private GameObject m_vid02;
	private GameObject m_vid03;
	private GameObject m_vid04;

	private GameObject m_resetButton;

	private GameObject m_gameTimer;
	private TextMeshProUGUI m_gameTimerText;

	private GameObject m_cameraMain;
	private Quaternion m_cameraRot;
	private float m_cameraRotY;
	private GameObject m_hudParent;
	private Vector3 m_hudParentRot;

	private GameObject m_notifAudio;

	private levelLogic m_LevelLogic;

	void Awake () {


		m_tmp_score = GameObject.Find("Player/GvrEditorEmulator/HUD-parent/HUD/open/Canvas/Panel/player-score").GetComponent<TextMeshProUGUI>();
		m_tmp_leveltwokey = GameObject.Find("Player/GvrEditorEmulator/HUD-parent/HUD/open/Canvas/Panel/player-key2").GetComponent<TextMeshProUGUI>();
		m_tmp_levelthreekey = GameObject.Find("Player/GvrEditorEmulator/HUD-parent/HUD/open/Canvas/Panel/player-key3").GetComponent<TextMeshProUGUI>();
		GameObject.Find ("Player/GvrEditorEmulator/HUD-parent/HUD/open").SetActive (false);
		m_tmp_notif = GameObject.Find("Player/GvrEditorEmulator/MainCamera/notif/Panel/message").GetComponent<TextMeshProUGUI>();
		GameObject.Find ("Player/GvrEditorEmulator/MainCamera/notif").SetActive (false);
		m_gameOver = GameObject.Find ("Player/GvrEditorEmulator/MainCamera/game_over");
		m_resetButton = GameObject.Find ("Player/GvrEditorEmulator/HUD-parent/HUD/restart");
		m_cameraMain = GameObject.Find ("Player/GvrEditorEmulator/MainCamera");
		m_hudParent = GameObject.Find ("Player/GvrEditorEmulator/HUD-parent");
		m_gameTimer = GameObject.Find ("Player/GvrEditorEmulator/HUD-parent/HUD/timer");
		m_gameTimerText = GameObject.Find("Player/GvrEditorEmulator/HUD-parent/HUD/timer/Panel/timer").GetComponent<TextMeshProUGUI>();
		m_notifAudio = GameObject.Find ("Player/GvrEditorEmulator/MainCamera/notif/notif_audio");
		m_LevelLogic = GameObject.FindObjectOfType<levelLogic>();
		if (m_LevelLogic != null) {
			m_tmp_playerhelp = GameObject.Find ("Player/GvrEditorEmulator/HUD-parent/HUD/open/Canvas/Panel/player-help").GetComponent<TextMeshProUGUI> ();
		}

		}


	void Start () {

		Scene currentScene = SceneManager.GetActiveScene ();

		// get the name of this scene
		string sceneName = currentScene.name;

		if (sceneName == "00-main-table") {

			if (gameLogic.m_levelTwoUlocked == false) {
				GameObject.Find ("Level2Lock/locked2").SetActive (true);
				GameObject.Find ("Level2Lock/unlocked2").SetActive (false);
				GameObject.Find ("fort-btn").SetActive (false);
				}

			if (gameLogic.m_levelThreeUlocked == false) {
				GameObject.Find ("Level3Lock/locked3").SetActive (true);
				GameObject.Find ("Level3Lock/unlocked3").SetActive (false);
				GameObject.Find ("dungeon-btn").SetActive (false);		
			}

			if (gameLogic.m_levelTwoUlocked == true) {
				GameObject.Find ("Level2Lock/locked2").SetActive (false);
				GameObject.Find ("Level2Lock/unlocked2").SetActive (true);
				GameObject.Find ("fort-btn").SetActive (true);
			}

			if (gameLogic.m_levelThreeUlocked == true) {
				GameObject.Find ("Level3Lock/locked3").SetActive (false);
				GameObject.Find ("Level3Lock/unlocked3").SetActive (true);	
				GameObject.Find ("dungeon-btn").SetActive (true);		
			}

			if (gameLogic.m_gameIsWon == true) {
			}
				

		}
			
		//we check the scene so that we don't reference variables that don't exist
		if (sceneName == "01-level-island-sm") {

			if (gameLogic.m_levelTwoUlocked == true) {
				GameObject.FindWithTag("key2").SetActive(false);
			}
		}
			
		if (sceneName == "02-level-fort") {

			if (gameLogic.m_levelThreeUlocked == true) {
				GameObject.FindWithTag("key3").SetActive(false);
			}

		}

	}
	
	void Update () {

		m_tmp_score.SetText("SCORE: " + m_playerScore);
		if (m_LevelLogic != null) {
			
			m_tmp_playerhelp.SetText (m_LevelLogic.m_startMsg);
		}

		if (m_playerScore == m_highestScore && m_highScoreShown == false) {
			DisplayNotif ("You just got the high score! Congratulations!", 3);
			m_highScoreShown = true;
		}


		if (m_levelTwoUlocked == true) {
			m_levelTwoKeyScore = "Unlocked!";
		} else {
			// leave the value unchanged.
		}

		if (m_levelThreeUlocked == true) {
			m_levelThreeKeyScore = "Unlocked!";
		} else {
			// leave the value unchanged.
		}

		m_tmp_leveltwokey.SetText("Level 2: " + m_levelTwoKeyScore);

		m_tmp_levelthreekey.SetText("Level 3: " + m_levelThreeKeyScore);


		if (m_gameIsWon == true) {
			m_resetButton.SetActive (true);
		}
			

		//Camera facing HUD stuff
		m_cameraRot = m_cameraMain.transform.rotation;
		m_cameraRotY = m_cameraRot.eulerAngles.y;


		if (m_cameraRotY >= -45 && m_cameraRotY <= 44) {
			m_hudParent.transform.eulerAngles = new Vector3 (0, 0, 0);
		
		} else if (m_cameraRotY >=45 && m_cameraRotY <= 134) {

			m_hudParent.transform.eulerAngles = new Vector3 (0, 90, 0);

		} else if (m_cameraRotY >= 135 && m_cameraRotY <= 224) {

			m_hudParent.transform.eulerAngles = new Vector3 (0, 180, 0);

		} else if (m_cameraRotY >= 225 && m_cameraRotY <= 314) {

			m_hudParent.transform.eulerAngles = new Vector3 (0, 270, 0);

		} 


	}


	public void WinGame() {
		if (m_playerScore == m_highestScore) {
			
			DisplayNotif ("You Won with the highest score!", 5);
		} else {
			DisplayNotif ("You Win!!", 5);

		}
		m_gameIsWon = true;
	}

	public void LevelTwoKey() {
		m_levelTwoUlocked = true;
		Debug.Log ("Level 2 Unlocked!");
		GameObject[] key2_array = GameObject.FindGameObjectsWithTag("key2");
		foreach (GameObject item in key2_array)
		{
			item.SetActive (false);
		}

		m_playerScore = m_playerScore + 100;
		DisplayNotif ("You just got the Map! Now find the flag before time is up!", 2);
	}
		
	public void LevelThreeKey() {
		m_levelThreeUlocked = true;
		Debug.Log ("Level 3 Unlocked!");
		GameObject[] key3_array = GameObject.FindGameObjectsWithTag("key3");
		foreach (GameObject item in key3_array)
		{
			item.SetActive (false);
		}
		m_playerScore = m_playerScore + 100;
		DisplayNotif ("You just got the Key! Now find the flag before time is up!", 2);
	}


	public void PickUpCoin() {
		Debug.Log ("Coin Score!");
		GameObject.FindWithTag("coin").SetActive(false);
		m_playerScore = m_playerScore + 1000;
		DisplayNotif ("You just got 1000 points! See if you can get the high score!", 2);
	}


	public void GetFinalKey() {
		m_finalKey = true;
		Debug.Log ("Final Treasure Unlocked!");
		GameObject.FindWithTag("key_final").SetActive(false);
		GameObject[] keyfinal_array = GameObject.FindGameObjectsWithTag("key_final");
		foreach (GameObject item in keyfinal_array)
		{
			item.SetActive (false);
		}
		m_playerScore = m_playerScore + 1000;
		DisplayNotif ("You just got the Key to unlock the Final Treasure!", 2);
	}

	public void OpenMenu() {
		GameObject.Find ("Player/GvrEditorEmulator/HUD-parent/HUD/open").SetActive (true);
		GameObject.Find ("Player/GvrEditorEmulator/HUD-parent/HUD/closed").SetActive (false);
	}

	public void CloseMenu() {
		GameObject.Find ("Player/GvrEditorEmulator/HUD-parent/HUD/open").SetActive (false);
		GameObject.Find ("Player/GvrEditorEmulator/HUD-parent/HUD/closed").SetActive (true);
	}


	public void EndGame () {
		RestartGame ();
		StartCoroutine(LoadNewScene("05-game-over"));
	}
		

	public void RestartGame () {
		m_levelTwoKeyScore = "Locked";
		m_levelThreeKeyScore = "Locked";
		m_playerScore = 0;
		m_levelTwoUlocked = false;
		m_levelThreeUlocked = false;
		m_finalKey = false;
		m_gameIsWon = false;
	}

// NOTIFICATION STUFF
	public void DisplayNotif(string message, int duration) {
		m_tmp_notif.SetText(message);
		StartCoroutine(ShowNotif(duration));
		StartCoroutine(PlaySoundFX(2));
	}

	IEnumerator ShowNotif(int duration)
	{
		GameObject.Find ("Player/GvrEditorEmulator/MainCamera/notif").SetActive (true);
		yield return new WaitForSeconds(duration);
		GameObject.Find ("Player/GvrEditorEmulator/MainCamera/notif").SetActive (false);
	}


	IEnumerator LoadNewScene(string sceneName) {

		// This line waits for 3 seconds before executing the next line in the coroutine.
		// This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
		yield return new WaitForSeconds(0);

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		AsyncOperation async = Application.LoadLevelAsync(sceneName);

		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
		while (!async.isDone) {
			yield return null;
		}

	}

	IEnumerator PlaySoundFX(int duration) {

		// This line waits for 3 seconds before executing the next line in the coroutine.
		// This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
		m_notifAudio.SetActive (true);
		yield return new WaitForSeconds(duration);
		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		m_notifAudio.SetActive (false);
		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.

	}
}
