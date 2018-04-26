using UnityEngine;
using System.Collections;

public class PlayButtom : MonoBehaviour {
	public GameObject Menu;
	public GameObject Play;
	public GameObject timer;
	public GameObject Pause;

	public GameObject GameController;

	void Start () {
		//何もしない
	}

	void Update () {
		//何もしない
	}
	public void OnClick() {
		GameControllerMain1 controller = GameController.GetComponent<GameControllerMain1> ();
		if (controller != null) {
			controller.StartGame ();
			TimeController time = timer.GetComponent<TimeController> ();
			time.time = true;
		}
		GameControllerMain01 controller01 = GameController.GetComponent<GameControllerMain01> ();
		if (controller01 != null) {
			controller01.StartGame ();
			TimeController01 time = timer.GetComponent<TimeController01> ();
			time.time = true;
		}
		GameControllerMain2 controller02 = GameController.GetComponent<GameControllerMain2> ();
		if (controller02 != null) {
			controller02.StartGame ();
			TimeController2 time = timer.GetComponent<TimeController2> ();
			time.time = true;
		}
		GameControllerMain03 controller03 = GameController.GetComponent<GameControllerMain03> ();
		if (controller03 != null) {
			controller03.StartGame ();
			TimeController03 time = timer.GetComponent<TimeController03> ();
			time.time = true;
		}
		GameControllerMain04 controller04 = GameController.GetComponent<GameControllerMain04> ();
		if (controller04 != null) {
			controller04.StartGame ();
			TimeController04 time = timer.GetComponent<TimeController04> ();
			time.time = true;
		}
		GameControllerMain05 controller05 = GameController.GetComponent<GameControllerMain05> ();
		if (controller05 != null) {
			controller05.StartGame ();
			TimeController05 time = timer.GetComponent<TimeController05> ();
			time.time = true;
		}
		GameControllerMain06 controller06 = GameController.GetComponent<GameControllerMain06> ();
		if (controller06 != null) {
			controller06.StartGame ();
			TimeController06 time = timer.GetComponent<TimeController06> ();
			time.time = true;
		}
		GameControllerMain07 controller07 = GameController.GetComponent<GameControllerMain07> ();
		if (controller07 != null) {
			controller07.StartGame ();
			TimeController07 time = timer.GetComponent<TimeController07> ();
			time.time = true;
		}
		GameControllerMain08 controller08 = GameController.GetComponent<GameControllerMain08> ();
		if (controller08 != null) {
			controller08.StartGame ();
			TimeController08 time = timer.GetComponent<TimeController08> ();
			time.time = true;
		}
		GameControllerMain09 controller09 = GameController.GetComponent<GameControllerMain09> ();
		if (controller09 != null) {
			controller09.StartGame ();
			TimeController09 time = timer.GetComponent<TimeController09> ();
			time.time = true;
		}
		GameControllerMain10 controller10 = GameController.GetComponent<GameControllerMain10> ();
		if (controller10 != null) {
			controller10.StartGame ();
			TimeController10 time = timer.GetComponent<TimeController10> ();
			time.time = true;
		}
		GameControllerMain11 controller11 = GameController.GetComponent<GameControllerMain11> ();
		if (controller11 != null) {
			controller11.StartGame ();
			TimeController11 time = timer.GetComponent<TimeController11> ();
			time.time = true;
		}
		GameControllerMain12 controller12 = GameController.GetComponent<GameControllerMain12> ();
		if (controller12 != null) {
			controller12.StartGame ();
			TimeController12 time = timer.GetComponent<TimeController12> ();
			time.time = true;
		}

		//Time.timeScale = 1;
		Menu.SetActive (false);
		Play.SetActive (false);
		Pause.SetActive (false);
	}
}