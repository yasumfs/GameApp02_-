using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	float sceneChangeTime;
	public AudioSource audioSource;
	private bool click = false;

	public void OnClick() {
		if (click == false) {
			audioSource.Play ();
			sceneChangeTime = 1f;
			click = true;
		}
	}

	void Start () {
		sceneChangeTime = -1f;
	}

	void Update () {
		if (sceneChangeTime > 0f) {
			sceneChangeTime -= Time.deltaTime;
			if (sceneChangeTime <= 0f) {
				SceneManager.LoadScene ("Start");
			}
		}
	}
}
