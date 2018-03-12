using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLogic : MonoBehaviour {

	public GameObject m_soundTeleport;
	public GameObject m_particleTeleport;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void GoToScene(string SceneName) {

		StartCoroutine(WaitAndLoad(SceneName));
	}

	IEnumerator WaitAndLoad(string SceneName)
	{
		print(Time.time);
		m_soundTeleport.SetActive (true);
		m_particleTeleport.SetActive (true);
		yield return new WaitForSeconds(2);
		print(Time.time);
		m_soundTeleport.SetActive (false);
		SceneManager.LoadScene (SceneName);
	}

}
