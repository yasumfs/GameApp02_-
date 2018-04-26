using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Move : MonoBehaviour {
	
	public float ClickCount = 0;
	Text text;
	public static float Count = 0;
	public GameObject Game;
	private bool CountOn;

	void Start () {
		text = this.GetComponent<Text>();
	}

	void Update () {
		//GameControllerで操作
		//if (Input.GetMouseButtonDown (0)) {
			//ClickCount++;
		GameControllerMain1 g = Game.GetComponent<GameControllerMain1> ();
		text.text = ClickCount.ToString ();
		if (CountOn == false) {
			if (g.gameClear == true) {
				Count += ClickCount;
				CountOn = true;
			}
		}
		//}
	}

	public static float MoveCount()
	{
		return Count;
	}
}
