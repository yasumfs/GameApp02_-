using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThunderController : MonoBehaviour {
	public GameObject Thunder1;
	public GameObject Thunder2;
	public GameObject Thunder3;
	float timer = 0;
	public GameObject Sound;

	void Start () {
		//何もしない
	}

	void Update () {
		timer += Time.deltaTime; 
		if (timer > 1) {
			Sound.SetActive (true);
			Thunder1.SetActive (true);
		}
		if (timer > 1.3) {
			Thunder1.SetActive (false);
			Thunder2.SetActive (true);
		}
		if (timer > 1.6) {
			Thunder2.SetActive (false);
			Thunder3.SetActive (true);
		}
		if (timer > 1.9) {
			Thunder3.SetActive (false);
			Sound.SetActive (false);
			timer = 0;
		}
	}
}
