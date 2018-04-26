using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Move08 : MonoBehaviour {
	public float ClickCount = 0;
	Text text;
	public static float Count = 0;
	public GameObject Game;
	private bool CountOn;

	void Start () {
		text = this.GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		text.text = ClickCount.ToString ();
		GameControllerMain08 g = Game.GetComponent<GameControllerMain08> ();
		if (CountOn == false) {
			if (g.gameClear == true) {
				Count += ClickCount;
				CountOn = true;
			}
		}
	}

	public static float MoveCount()
	{
		return Count;
	}
}