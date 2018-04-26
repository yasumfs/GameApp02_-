using UnityEngine;
using System.Collections;

public class TimeButtom : MonoBehaviour {
	public GameObject GameController;
	public GameObject Menu;
	public GameObject Play;
	public GameObject timer;
	public GameObject Pause;

	void Start () {
		//何もしない
	}

	void Update () {
		//何もしない
	}

	public void OnClick() {
		GameControllerMain1 controller = GameController.GetComponent<GameControllerMain1> ();
		if (controller != null) {
			//Debug.Log ("Begin!!");
			controller.BeginGame ();
			TimeController time = timer.GetComponent<TimeController> ();
			time.time = false;
		}
		GameControllerMain01 controller01 = GameController.GetComponent<GameControllerMain01> ();
		if (controller01 != null) {
			controller01.BeginGame ();
			TimeController01 time = timer.GetComponent<TimeController01> ();
			time.time = false;
		}
		GameControllerMain2 controller02 = GameController.GetComponent<GameControllerMain2> ();
		if (controller02 != null) {
			controller02.BeginGame ();
			TimeController2 time = timer.GetComponent<TimeController2> ();
			time.time = false;
		}
		GameControllerMain03 controller03 = GameController.GetComponent<GameControllerMain03> ();
		if (controller03 != null) {
			controller03.BeginGame ();
			TimeController03 time = timer.GetComponent<TimeController03> ();
			time.time = false;
		}
		GameControllerMain04 controller04 = GameController.GetComponent<GameControllerMain04> ();
		if (controller04 != null) {
			controller04.BeginGame ();
			TimeController04 time = timer.GetComponent<TimeController04> ();
			time.time = false;
		}
		GameControllerMain05 controller05 = GameController.GetComponent<GameControllerMain05> ();
		if (controller05 != null) {
			controller05.BeginGame ();
			TimeController05 time = timer.GetComponent<TimeController05> ();
			time.time = false;
		}
		GameControllerMain06 controller06 = GameController.GetComponent<GameControllerMain06> ();
		if (controller06 != null) {
			controller06.BeginGame ();
			TimeController06 time = timer.GetComponent<TimeController06> ();
			time.time = false;
		}
		GameControllerMain07 controller07 = GameController.GetComponent<GameControllerMain07> ();
		if (controller07 != null) {
			controller07.BeginGame ();
			TimeController07 time = timer.GetComponent<TimeController07> ();
			time.time = false;
		}
		GameControllerMain08 controller08 = GameController.GetComponent<GameControllerMain08> ();
		if (controller08 != null) {
			controller08.BeginGame ();
			TimeController08 time = timer.GetComponent<TimeController08> ();
			time.time = false;
		}
		GameControllerMain09 controller09 = GameController.GetComponent<GameControllerMain09> ();
		if (controller09 != null) {
			controller09.BeginGame ();
			TimeController09 time = timer.GetComponent<TimeController09> ();
			time.time = false;
		}
		GameControllerMain10 controller10 = GameController.GetComponent<GameControllerMain10> ();
		if (controller10 != null) {
			controller10.BeginGame ();
			TimeController10 time = timer.GetComponent<TimeController10> ();
			time.time = false;
		}
		GameControllerMain11 controller11 = GameController.GetComponent<GameControllerMain11> ();
		if (controller11 != null) {
			controller11.BeginGame ();
			TimeController11 time = timer.GetComponent<TimeController11> ();
			time.time = false;
		}
		GameControllerMain12 controller12 = GameController.GetComponent<GameControllerMain12> ();
		if (controller12 != null) {
			controller12.BeginGame ();
			TimeController12 time = timer.GetComponent<TimeController12> ();
			time.time = false;
		}

		//Time.timeScale = 0;
		Menu.SetActive (true);
		Play.SetActive (true);
		Pause.SetActive (true);
	}
}
