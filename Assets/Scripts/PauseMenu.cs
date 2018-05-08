using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	public AudioSource buttonPress;

	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
		{
			if (GameIsPaused) 
			{
				Resume ();
			} else 
			{
				Pause ();
			}
		}
	}

	public void Resume()
	{
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
		Cursor.lockState = CursorLockMode.Locked;
		GameObject.Find ("Main Camera").GetComponent <MouseAimCamera>().enabled = true;
		buttonPress.Play ();
	}

	void Pause()
	{
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
		Cursor.lockState = CursorLockMode.None;
		GameObject.Find ("Main Camera").GetComponent <MouseAimCamera>().enabled = false;
		buttonPress.Play ();
	}

	public void LoadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
	}

	public void QuitGame()
	{
		Debug.Log ("Quit");
		Application.Quit ();
	}
}
