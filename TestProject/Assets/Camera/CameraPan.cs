using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindWithTag("Player");
	}

	void LateUpdate ()
	{
//		float zPos = player.transform.position.z;
//		transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
		transform.LookAt(player.transform);
	}
}
