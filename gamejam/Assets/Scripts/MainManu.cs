using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManu : MonoBehaviour {

	public string startLevel;

	public void NewGame()
	{
		Application.LoadLevel(startLevel);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
