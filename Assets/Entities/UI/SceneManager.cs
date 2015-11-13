﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneManager : MonoBehaviour {
	private OptionMenuManager optionMenu;

	public void ExitGame() {
		Application.Quit ();
	}

	void Start() {
		optionMenu = FindObjectOfType<OptionMenuManager> ();
	}
	
	void Update() {
		if (optionMenu) {
			if (Input.GetKeyDown (optionMenu.keyCodeForOptionMenu)) {
				optionMenu.showOptionMenu ();
			}
		}
	}

	public void StartGame() {
		ScoreTracker.Reset ();
		LoadNextLevel ();
	}

	public void LoadLevel(string levelName) {
		Debug.Log ("Load Level");
		Application.LoadLevel (levelName);
	}


	public void LoadNextLevel() {
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public static SceneManager GetInstance() {
		return FindObjectOfType<SceneManager> ();
	}

}
