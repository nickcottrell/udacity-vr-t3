using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameLogic : MonoBehaviour {

	public Camera m_camera;
	public GameObject m_labelOne;
	public GameObject m_previewOne;          
	public GameObject m_pointOne;
	public GameObject m_labelTwo;
	public GameObject m_previewTwo;          
	public GameObject m_pointTwo; 
	public GameObject m_labelThree;
	public GameObject m_previewThree;          
	public GameObject m_pointThree; 
	private LineRenderer m_lineOne;
	private LineRenderer m_lineTwo;
	private LineRenderer m_lineThree;
	public Material m_lineMaterial;



	void Start () {

		// NO IDEA why this has to be set up like that. I tried wrapping it in a method but that didn't work.

		m_lineOne = m_pointOne.gameObject.AddComponent<LineRenderer>();
		m_lineOne.material = m_lineMaterial;
		// Set the width of the Line Renderer
		m_lineOne.SetWidth(0.01F, 0.01F);
		// Set the number of vertex fo the Line Renderer
		m_lineOne.SetVertexCount(2);

		m_lineTwo = m_pointTwo.gameObject.AddComponent<LineRenderer>();
		m_lineTwo.material = m_lineMaterial;
		// Set the width of the Line Renderer
		m_lineTwo.SetWidth(0.01F, 0.01F);
		// Set the number of vertex fo the Line Renderer
		m_lineTwo.SetVertexCount(2);

		m_lineThree = m_pointThree.gameObject.AddComponent<LineRenderer>();
		m_lineThree.material = m_lineMaterial;
		// Set the width of the Line Renderer
		m_lineThree.SetWidth(0.01F, 0.01F);
		// Set the number of vertex fo the Line Renderer
		m_lineThree.SetVertexCount(2);


	}
	

	void Update () {

		FaceCamera (m_labelOne);
		FaceCamera (m_labelTwo);
		FaceCamera (m_labelThree);
		DrawLine (m_lineOne, m_previewOne, m_pointOne);
		DrawLine (m_lineTwo, m_previewTwo, m_pointTwo);
		DrawLine (m_lineThree, m_previewThree, m_pointThree);

	}

	public void GoToScene(string SceneName) {
		Debug.Log ("My method was called.");
		SceneManager.LoadScene (SceneName);
	}

	void FaceCamera(GameObject labelName)
	{
		Vector3 v = m_camera.transform.position - transform.position;
		v.x = v.z = 0.0f;
		labelName.transform.LookAt( m_camera.transform.position - v ); 
		labelName.transform.Rotate(0,180,0);
	}

	void DrawLine(LineRenderer line, GameObject obj1, GameObject obj2)
	{
		// Check if the GameObjects are not null
		if (obj1 != null && obj2 != null)
		{
			// Update position of the two vertex of the Line Renderer
			line.SetPosition(0, obj1.transform.position);
			line.SetPosition(1, obj2.transform.position);
		}
	}


}
