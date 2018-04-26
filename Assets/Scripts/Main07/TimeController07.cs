using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeController07 : MonoBehaviour {
	public GameObject Game2;
	public GameObject GameOver;
	public GameObject move;
	public GameObject MenuButtom;
	public GameObject ContinueButtom;
	private float GameOverTime;
	private static float RemainingTime = 0;
	private bool count = false;
	public GameObject Char;
	public GameObject QuickChar;
	public GameObject TimeOverChar;
	public GameObject BGM_GameOver;
	public AudioSource BGM;

	Text text;
	public float timer = 45;
	public bool time = true;

	void Start () {
		Time.timeScale = 1;
		text = this.GetComponent<Text>();
	}


	void Update () {
		if (time == true) {
			timer -= Time.deltaTime;
			text.text = ((int)timer).ToString ();
		}
		//クリア条件になったらtimer停止
		GameControllerMain07 game07 =Game2.GetComponent<GameControllerMain07>();
		if (timer < 11) {
			Char.SetActive (false);
			QuickChar.SetActive (true);
			BGM.pitch = 2;
		}

		if (timer < 1) {
			Move07 m07 = move.GetComponent<Move07>();
			m07.ClickCount = 0;
			game07.gameClear = true;
			time = false;
			GameOverTime += Time.deltaTime;
			QuickChar.SetActive (false);
			TimeOverChar.SetActive (true);
			BGM_GameOver.SetActive(true);
			BGM.Stop ();
			if (GameOverTime > 1) {
				GameOver.SetActive (true);
				ContinueButtom.SetActive (true);
				MenuButtom.SetActive (true);
			}
		}
		if (game07.gameClear == true) {
			if (count == false) {
				RemainingTime += timer;
				count = true;
			}
		}
	}
	public static float PlusTime(){
		return RemainingTime;
	}
}
