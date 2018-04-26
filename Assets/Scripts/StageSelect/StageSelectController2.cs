using UnityEngine;
using System.Collections;

public class StageSelectController2 : MonoBehaviour {
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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClick () {
		Camera.transform.position = new Vector3 (0f, 0f,-10f);
		stage1.SetActive (true);
		stage2.SetActive (true);
		stage3.SetActive (true);
		stage4.SetActive (true);
		stage5.SetActive (true);
		stage6.SetActive (true);
		Tutorial1.SetActive (true);
		Tutorial2.SetActive (true);
		stage7.SetActive (false);
		stage8.SetActive (false);
		stage9.SetActive (false);
		stage10.SetActive (false);
		stage11.SetActive (false);
		stage12.SetActive (false);
		stage13.SetActive (false);
		triangle.SetActive (true);
		back.SetActive (false);
	}
}
