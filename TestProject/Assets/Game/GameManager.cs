using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	private float initialFixedDelta;

	public bool recording = true;
	public bool paused = false;

	void Start ()
	{
		PlayerPrefsManager.UnlockLevel(2);
		Debug.Log(PlayerPrefsManager.IsLevelUnlocked(1));
		Debug.Log(PlayerPrefsManager.IsLevelUnlocked(2));
		initialFixedDelta = Time.fixedDeltaTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (CrossPlatformInputManager.GetButton("Fire1"))
			recording = false;
		else
			recording = true;

		if (Input.GetKeyDown(KeyCode.P) && !paused)
		{
			PauseGame();
		}
		else if (Input.GetKeyDown(KeyCode.P) && paused)
		{
			ResumeGame();
		}
	}

	void PauseGame ()
	{
		paused = true;
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
	}

	void ResumeGame ()
	{
		paused = false;
		Time.timeScale = 1f;
		Time.fixedDeltaTime = initialFixedDelta;
	}
}
