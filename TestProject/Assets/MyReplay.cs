using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyReplay : MonoBehaviour {

	private const int BUFFER_FRAMES = 100;
	private GameManager gameManager;
	private MyKeyFrame[] keyFrames = new MyKeyFrame[BUFFER_FRAMES];
	private Rigidbody myRigidbody;

	// Use this for initialization
	void Start ()
	{
		gameManager = FindObjectOfType<GameManager>();
		myRigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update ()
	{
		if (gameManager.recording)
			Record();
		else
			Playback();
	}

	public void Playback ()
	{
		myRigidbody.isKinematic = true;
		int frame = Time.frameCount % BUFFER_FRAMES;
		print ("Reading frame " + frame);
		transform.position = keyFrames[frame].position;
		transform.rotation = keyFrames[frame].rotation;
	}

	void Record ()
	{
		myRigidbody.isKinematic = false;
		int frame = Time.frameCount % BUFFER_FRAMES;
		print ("Writing frame " + frame);
		keyFrames [frame] = new MyKeyFrame (Time.time, transform.position, transform.rotation);
	}
}

/// <summary>
/// A structure for storing time, position, and rotation.
/// </summary>
public struct MyKeyFrame
{
	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;

	public MyKeyFrame (float aTime, Vector3 aPos, Quaternion aRot)
	{
		frameTime = aTime;
		position = aPos;
		rotation = aRot;
	}
}
