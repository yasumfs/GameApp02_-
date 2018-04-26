﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToMain12 : MonoBehaviour {

	public AudioSource audioSource;
	float sceneChangeTime;
	private bool click = false;

	void Start () {
		Time.timeScale = 1;
		sceneChangeTime = -1f;
	}

	public void OnClick() {
		if (click == false) {
			audioSource.Play ();
			sceneChangeTime = 1f;
			click = true;
		}
	}

	void Update () {
		if (sceneChangeTime > 0f) {
			sceneChangeTime -= Time.deltaTime;
			if (sceneChangeTime <= 0f) {
				SceneManager.LoadScene ("Main12");
			}
		}
	}
}