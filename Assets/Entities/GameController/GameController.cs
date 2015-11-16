﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public Text ReadyPlayerOneText;
	public float MessageDelay;
	public Text WaveText;
	public bool GameIsReady = false;
	public int WaveNumber = 0;
	public float volume = 0.5f;

	public AudioClip WaveSpawned;


	public static GameController GetInstance() {
		return GameObject.FindObjectOfType<GameController> ();
	}

	public static void PlayerOneSpawning() {
		GetInstance ().ShowPlayerOneText ();
		NextWave ();
	}

	public static void PlayerDied() {
		GetInstance ().GameIsReady = false;
	}

	public static void NextWave() {
		GetInstance().ShowWaveText ();
	}

	void ShowWaveText() {
		WaveNumber++;
		WaveText.text = "Wave " + WaveNumber;
		WaveText.enabled = true;
		Invoke ("HideWaveText", MessageDelay);
		GameIsReady = false;
	}

	void HideWaveText() {
		WaveText.enabled = false;
		GameIsReady = true;
		AudioSource.PlayClipAtPoint (WaveSpawned, this.transform.position, volume);
	}

	void ShowPlayerOneText() {
		ReadyPlayerOneText.enabled = true;
		Invoke ("HidePlayerOneText", MessageDelay);
		GameIsReady = false;
	}

	void HidePlayerOneText() {
		ReadyPlayerOneText.enabled = false;
		GameIsReady = true;
	}


	public static bool GameReady() {
		return GetInstance().GameIsReady;
	}
}
