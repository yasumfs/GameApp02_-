using UnityEngine;
using System.Collections;

public class GameOverCharController2 : MonoBehaviour {

	public float timer = 0;
	public GameObject Char1;
	public GameObject Char2;
	public GameObject Char3;
	public GameObject Char4;
	public GameObject Failure;
	public GameObject Canvas;
	public GameObject BGM;

	void Start () {
		Time.timeScale = 1;
	}

	void Update () {
		timer += Time.deltaTime;
		if (timer >= 0.5) {
			Char1.SetActive (false);
			Char2.SetActive (true);
		}
		if (timer >= 1 ) {
			Char2.SetActive (false);
			Char3.SetActive (true);
		}
		if (timer >= 1.5) {
			Char3.SetActive (false);
			Char4.SetActive (true);
		}
		if (timer >= 2) {
			BGM.SetActive (true);
			Failure.SetActive(true);
		}
		if (timer >= 2.5) {
			Canvas.SetActive (true);
		}
	}
}
