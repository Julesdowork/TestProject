using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfieStick : MonoBehaviour {

	private GameObject player;
	private Vector3 armRotation;

	public float panSpeed = 10f;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindWithTag("Player");
		armRotation = transform.rotation.eulerAngles;
	}
	
	void Update ()
	{
		armRotation.y += Input.GetAxis("RHoriz") * panSpeed;
		armRotation.x += Input.GetAxis("RVert") * panSpeed;
		transform.position = player.transform.position;
		transform.rotation = Quaternion.Euler(armRotation);
	}
}
