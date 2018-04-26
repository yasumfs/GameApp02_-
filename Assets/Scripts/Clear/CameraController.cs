using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour {
	//public GameObject Camera;

	public GameObject Buttum;
	public float speed = 50;
	private bool start = false, end = false;
	public GameObject Flash;
	public float timer = 0;
	public float timer1 = 0;
	public AudioSource audioSource;
	public AudioSource audioSource1;
	public AudioSource audioSource2;
	public GameObject right;
	public GameObject background;


	void Start () {
		Time.timeScale = 1;
	}

	void Update () {
		timer1 += Time.deltaTime;
		if (timer1 > 3) {
			right.SetActive (false);
			background.SetActive (false);
			if (!start && !end) {
				if (this.transform.position.x >= 740 /*&& this.transform.position.y <= 170*/) {
					this.transform.Translate (Vector3.left * speed * Time.deltaTime);
				}
				if (this.transform.position.x <= 740 && this.transform.position.y <= 170) {
					this.transform.Translate (Vector3.up * speed * Time.deltaTime);
				} 
				if (this.transform.position.x >= 524 && this.transform.position.y >= 170) {
					this.transform.Translate (Vector3.left * speed * Time.deltaTime);
				}
			}
			if (this.transform.position.x <= 524 && this.transform.position.y >= -39) {
				start = true;
			}
			if (start && !end) {
				if (this.transform.position.x <= 524 && this.transform.position.y >= 22) {
					this.transform.Translate (Vector3.down * speed * Time.deltaTime);
				}
				if (this.transform.position.x >= 310 && this.transform.position.y <= 22) {
					this.transform.Translate (Vector3.left * speed * Time.deltaTime);
				}

			}
			if (this.transform.position.x <= 310 && this.transform.position.y <= 279) {
				end = true;
				if (this.transform.position.x <= 310 && this.transform.position.y <= 279) {
					this.transform.Translate (Vector3.up * speed * Time.deltaTime);
				}
				if (this.transform.position.x <= 310 && this.transform.position.y >= 279) {
					audioSource.Stop ();
					audioSource1.Play ();
					audioSource2.Play ();
					timer += Time.deltaTime;
					Flash.SetActive (true);
					//if (timer >= 5) {
					Buttum.SetActive (true);
					//}
				}
			}
		}
	}
}