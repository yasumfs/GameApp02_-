using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController05 : MonoBehaviour {
	public GameObject Game;
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
	public float timer = 30;
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
		GameControllerMain05 g =Game.GetComponent<GameControllerMain05>();
		if (timer < 11) {
			Char.SetActive (false);
			QuickChar.SetActive (true);
			BGM.pitch = 2;
		}

		if (timer < 1) {
			Move05 move05 = move.GetComponent<Move05> ();
			move05.ClickCount = 0;
			g.gameClear = true;
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
		if (g.gameClear == true) {
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
