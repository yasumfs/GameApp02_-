using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClick() {
		Time.timeScale = 1;
		SceneManager.LoadScene ("Start");
	}
}
