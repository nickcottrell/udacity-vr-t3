using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {

	private GameObject m_loadingUI;
	private gameLogic m_gameLogic;
	//private GameObject m_gameOverUI;
	private GameObject m_newGameLoadingUI;

	void Awake() {
		m_gameLogic = GameObject.FindObjectOfType<gameLogic>();
	}

	void Start () {
		m_loadingUI = GameObject.Find ("Player/GvrEditorEmulator/MainCamera/loading_ui");
		//m_gameOverUI = GameObject.Find ("Player/GvrEditorEmulator/MainCamera/game_over");
		m_newGameLoadingUI = GameObject.Find ("Player/GvrEditorEmulator/MainCamera/game_over/Canvas/restartmessage");
		//m_loadingUI.SetActive (false);

	}

	void Update () {

	}
		
	public void LoadFresh() {
		m_newGameLoadingUI.SetActive(true);
		m_gameLogic.RestartGame ();
		StartCoroutine(LoadNewScene("04-restarter"));
	}


	public void LoadNewGame() {
		m_loadingUI.SetActive (true);
		m_gameLogic.RestartGame ();
		StartCoroutine(LoadNewScene("04-restarter"));
	}


	public void GoToScene(string sceneName) {
			//m_loadingUI.SetActive (true);
			StartCoroutine(LoadNewScene(sceneName));
	}


	public void GoToSceneTwo() {
		if (gameLogic.m_levelTwoUlocked == true) {
			m_loadingUI.SetActive (true);
			StartCoroutine (LoadNewScene ("02-level-fort-loader"));
			gameLogic.m_playerScore = gameLogic.m_playerScore + 500;
		} else {
			m_gameLogic.DisplayNotif ("Level 2 is locked! You need the key.", 2);

			Debug.Log ("Level 2 is locked! You need the key.");
		}
	}


	public void GoToSceneThree() {
		if (gameLogic.m_levelThreeUlocked == true) {
			m_loadingUI.SetActive (true);
			StartCoroutine (LoadNewScene ("03-level-dungeon-loader"));
			gameLogic.m_playerScore = gameLogic.m_playerScore + 500;
		} else {
			m_gameLogic.DisplayNotif ("Level 3 is locked! You need the key.", 2);
			Debug.Log ("Level 3 is locked! You need the key.");
		}
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
}
