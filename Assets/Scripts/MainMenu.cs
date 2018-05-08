using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


	public void PlayGame ()
	{
		Invoke ("ChangeScene", 1f);
	}

	public void QuitGame()
	{
		Debug.Log ("Quit");
		Application.Quit ();
	}

	void ChangeScene()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
