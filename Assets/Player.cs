using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour {
	public WheelCollider[] m_WheelColliders = new WheelCollider[2];
	public GameObject[] m_WheelMeshes = new GameObject[2];
	private float m_TopSpeed = 15.0f;

	static Player _instance = null;

	CharacterController m_cc;
	Rigidbody m_rb;

	public bool m_AccelAct;
	public bool m_RevAct;

	private float m_rotateSpeed;
	[SerializeField] private float m_speed;
	Vector3 m_moveDirection = Vector3.zero;

	//public float m_CurrentSpeed{ get { return m_rb.velocity.magnitude*2.23693629f; }}
	//public float m_MaxSpeed{get { return m_TopSpeed; }}

	// Use this for initialization
	void Awake (){
		m_rotateSpeed = 100.0f;
		m_AccelAct = false;
		m_RevAct = false;

		m_speed = 50.0f;
		m_cc = GetComponent<CharacterController> ();
		m_rb = GetComponent<Rigidbody>();

		if (instance) {
			DestroyImmediate (gameObject); //game manager exists, delete the copy
		} else {
			DontDestroyOnLoad(this); //used so the title screen and attached script do not get destroyed on load
			instance = this;
		}
	}
		
	// Update is called once per frame
	void Update () {
//		#if UNITY_EDITOR
//
//		if (Input.GetButton ("Jump")) {
//			m_speed = 8.0f;
//		} else {
//			m_speed = 5.0f;
//		}
//
//		transform.Rotate (0, Input.GetAxis ("Horizontal") * -m_rotateSpeed, 0);
//		float curSpeed = m_speed * Input.GetAxis ("Vertical");
//		m_cc.SimpleMove (transform.right * -curSpeed);
//
//		if (Input.GetKey ("a")) {
//			transform.Rotate (0, 0, -m_rotateSpeed);
//		}
//		if (Input.GetKey ("d")) {
//			transform.Rotate (0, 0, m_rotateSpeed);
//		}
//
//		#endif
//

		#if UNITY_IOS || UNITY_EDITOR


		if (Input.touchCount == 1)
		{
			Debug.Log ("first touch is working");
		}
		else if (Input.touchCount == 2)
		{
			Debug.Log ("second touch is working");
		}
		else 
		{
		//	m_rb.velocity = new Vector3 (0, 0, 0);

		}

		transform.Rotate (0, 0, Input.acceleration.x * Time.deltaTime * m_rotateSpeed);


		if (m_AccelAct == true)
		{
			m_rb.velocity = new Vector3 (m_speed, 0, 0);
		}
		else if (m_RevAct == true)
		{
			m_rb.velocity = new Vector3 (-m_speed, 0, 0);
		}
		else 
		{
			m_rb.velocity = new Vector3 (0, 0, 0);

		}

		#endif
	}
	public static Player instance {
		get 
		{
			//			if (_instance == null) 
			//			{
			//				_instance = this;
			//			}
			return _instance; 

		} // can also use just get;
		set {_instance = value; } // can also use just set;

	}

	public void BeginAccelerate ()
	{
		Debug.Log ("should be accel");
		m_AccelAct = true;
	}

	public void StopAccelerate ()
	{
		m_AccelAct = false;
	}


	public void BeginReverse ()
	{
		Debug.Log ("should be rev");
		m_RevAct = true;
	}
	public void StopReverse ()
	{
		m_RevAct = false;
	}
}
