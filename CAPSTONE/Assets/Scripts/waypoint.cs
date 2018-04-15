using UnityEngine;
using System.Collections;

public class waypoint : MonoBehaviour
{
	private enum State
	{
		Idle,
		Focused,
		Clicked,
		Approaching,
		Moving,
		Collect,
		Collected,
		Occupied,
		Open,
		Hidden
	}
		
	[SerializeField]
	private State  		_state					= State.Idle;
	private Color		_color_origional		= new Color(0.0f, 1.0f, 0.0f, 0.5f);
	private Color		_color					= Color.white;
	private float 		_scale					= 1.0f;
	private float 		_animated_lerp			= 1.0f;
	private AudioSource _audio_source			= null;

	[Header("Material")]
	public Material m_materialIdle				= null;
	public Material m_materialHover 			= null;

	[Header("State Blend Speeds")]
	public float lerp_idle 						= 0.0f;
	public float lerp_focus 					= 0.0f;
	public float lerp_hide						= 0.0f;
	public float lerp_clicked					= 0.0f;
	
	[Header("State Animation Scales")]
	public float scale_clicked_max				= 0.0f;
	public float scale_animation				= 3.0f;	
	public float scale_idle_min 				= 0.0f;
	public float scale_idle_max 				= 0.0f;
	public float scale_focus_min				= 0.0f;
	public float scale_focus_max				= 0.0f;

	[Header("Sounds")]
	public AudioClip clip_click					= null;				

	[Header("Hide Distance")]
	public float threshold						= 0.125f;

	void Awake()
	{		

		_color						= _color_origional;
		_audio_source				= gameObject.GetComponent<AudioSource>();	
		_audio_source.clip		 	= clip_click;
		_audio_source.playOnAwake 	= false;
	}

	void Update()
	{
		bool occupied 	= Camera.main.transform.parent.transform.position == gameObject.transform.position;
		//bool occupied 	= m_player.transform.position == gameObject.transform.position;

		switch(_state)
		{
			case State.Idle:
				Idle();
				
				_state 		= occupied ? State.Occupied : _state;
				break;

			case State.Focused:
				Focus();
				break;

			case State.Clicked:
				Clicked();

				bool scaled = _scale >= scale_clicked_max * .95f;
				_state 		= scaled ? State.Approaching : _state;
				break;

			case State.Approaching:
				Hide();	

				_state 		= occupied ? State.Occupied : _state;
				break;
			case State.Occupied:
				Hide();

				_state = !occupied ? State.Idle : _state;
				break;
			
			case State.Hidden:
				Hide();
				break;

			default:
				break;
		}

		gameObject.transform.localScale 									= Vector3.one * _scale;
		_animated_lerp														= Mathf.Abs(Mathf.Cos(Time.time * scale_animation));
	}


	public void Enter()
	{
		_state = _state == State.Idle ? State.Focused : _state;
	}


	public void Exit()
	{
		_state = State.Idle;
	}


	public void Click()
	{
		_state = _state == State.Focused ? State.Clicked : _state;
		
		_audio_source.Play();

		Camera.main.transform.parent.transform.position = gameObject.transform.position;
	}


	private void Idle()
	{
		_scale					= Mathf.Lerp(_scale, 		1.0f, lerp_idle);
		_color					= Color.Lerp(_color, Color.clear, lerp_idle);
		gameObject.GetComponentInChildren<MeshRenderer>().material 	= m_materialIdle;


	}


	public void Focus()
	{

		gameObject.GetComponentInChildren<MeshRenderer>().material 	= m_materialHover;

	}


	public void Clicked()
	{	
		
	}


	public void Hide()
	{
		_scale					= Mathf.Lerp(_scale, 		0.0f, lerp_hide);
		_color					= Color.Lerp(_color, _color_origional, lerp_hide);
	}
}
