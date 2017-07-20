using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour {
	private WheelCollider[] m_WheelColliders = new WheelCollider[2];
	private GameObject[] m_WheelMeshes = new GameObject[2];
	private float m_TopSpeed = 15.0f;



	CharacterController m_cc;
	Rigidbody m_rb;




	private float rotateSpeed = 5.0f;
	private float speed = 5.0f;
	private float speedB = 7.0f;
	Vector3 moveDirection = Vector3.zero;

	public float CurrentSpeed{ get { return m_rb.velocity.magnitude*2.23693629f; }}
	public float MaxSpeed{get { return m_TopSpeed; }};

	// Use this for initialization
	void Start () {
		m_cc = GetComponent<CharacterController> ();
		m_rb = GetComponent<Rigidbody>();


	}

	// Update is called once per frame
	void Update () {
	
		transform.Rotate (0, 0, Input.GetAxis ("Vertical") * -rotateSpeed);
		float curSpeed = speed * Input.GetAxis ("Horizontal");
		cc.SimpleMove (transform.right * -curSpeed);

	
	}
}
