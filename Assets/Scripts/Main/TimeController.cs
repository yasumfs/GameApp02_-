using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour {
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
	public float timer = 25;
	public bool time = true;

	void Start () {
		Time.timeScale = 1;
		text = this.GetComponent<Text>();
		//Game = GameObject.Find("GameController");
	}
		

	void Update () {
		GameControllerMain1 g = Game.GetComponent<GameControllerMain1> ();
		if (time == true) {
			timer -= Time.deltaTime;
			text.text = ((int)timer).ToString ();
		}
		if (g.gameClear == true) {
			if (count == false) {
				RemainingTime += timer;
				count = true;
			}
		}

		//クリア条件になったらtimer停止
		/*if (g.obj1.transform.position.x == 88 &&
			g.obj1.transform.position.y == 315 &&

			g.obj2.transform.position.x == 88 &&
			g.obj2.transform.position.y == 174 &&

			g.obj3.transform.position.x == 348 &&
			g.obj3.transform.position.y == 174 &&

			g.obj4.transform.position.x == 348 &&
			g.obj4.transform.position.y == 315 &&

			g.obj5.transform.position.x == 609 &&
			g.obj5.transform.position.y == 315 &&

			g.obj6.transform.position.x == 609 &&
			g.obj6.transform.position.y == 174) {
			Time.timeScale = 0;
		}
		if (g.obj1.transform.position.x == 609 &&
			g.obj1.transform.position.y == 174 &&

			g.obj2.transform.position.x == 88 &&
			g.obj2.transform.position.y == 174 &&

			g.obj3.transform.position.x == 348 &&
			g.obj3.transform.position.y == 174 &&

			g.obj4.transform.position.x == 348 &&
			g.obj4.transform.position.y == 315 &&

			g.obj5.transform.position.x == 609 &&
			g.obj5.transform.position.y == 315 &&

			g.obj6.transform.position.x == 88 &&
			g.obj6.transform.position.y == 315) {
			Time.timeScale = 0;
		}*/
		if (timer < 11) {
			Char.SetActive (false);
			QuickChar.SetActive (true);
			BGM.pitch = 2;
		}
		if (timer < 1) {
			Move m = move.GetComponent<Move>();
			m.ClickCount = 0;
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
	}

	/*public void BeginGame()
	{
		gameState = GameState.Start;
	}

	public void StartGame()
	{
		gameState = GameState.Play;
	}

	public void ClearGame()
	{
		gameState = GameState.Clear;
	}*/

	public static float PlusTime(){
		return RemainingTime;
	}
}
