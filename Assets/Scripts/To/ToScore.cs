using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToScore : MonoBehaviour {

	public AudioSource audioSource;
	float sceneChangeTime;

	void Start () {
		//audioSource = gameObject.GetComponent<AudioSource>();
		//StartCoroutine("time");
		Time.timeScale = 1;
		sceneChangeTime = -1f;
	}

	public void OnClick() {
		audioSource.Play();
		sceneChangeTime = 1f;
	}

	/*public IEnumerator time() {  
		if (Input.GetMouseButtonDown (0)) {
			audioSource.Play();
			yield return new WaitForSeconds (1.0f);
			SceneManager.LoadScene ("Main");
		}
	}*/

	void Update () {
		if (sceneChangeTime > 0f) {
			sceneChangeTime -= Time.deltaTime;
			if (sceneChangeTime <= 0f) {
				SceneManager.LoadScene ("Score");
			}
		}
	}
}
