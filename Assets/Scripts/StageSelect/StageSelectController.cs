using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageSelectController : MonoBehaviour {
	public GameObject Camera;
	public AudioSource audioSource;
	public GameObject Tutorial1;
	public GameObject Tutorial2;
	public GameObject stage1;
	public GameObject stage2;
	public GameObject stage3;
	public GameObject stage4;
	public GameObject stage5;
	public GameObject stage6;
	public GameObject stage7;
	public GameObject stage8;
	public GameObject stage9;
	public GameObject stage10;
	public GameObject stage11;
	public GameObject stage12;
	public GameObject stage13;
	public GameObject triangle;
	public GameObject back;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnClick () {
		Camera.transform.position = new Vector3 (20f, 0f,-10f);
		stage1.SetActive (false);
		stage2.SetActive (false);
		stage3.SetActive (false);
		stage4.SetActive (false);
		stage5.SetActive (false);
		stage6.SetActive (false);
		Tutorial1.SetActive (false);
		Tutorial2.SetActive (false);
		stage7.SetActive (true);
		stage8.SetActive (true);
		stage9.SetActive (true);
		stage10.SetActive (true);
		stage11.SetActive (true);
		stage12.SetActive (true);
		stage13.SetActive (true);
		triangle.SetActive (false);
		back.SetActive (true);
	}
}