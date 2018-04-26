using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	private float AllMoveCount = 0 ;
	public Text text;
	public static float FinalMoveCount = 0;

	void Start () {
		text = this.GetComponent<Text>();
		float resultCount = Move.MoveCount();
		float resultCount01 = Move01.MoveCount();
		float resultCount02 = Move2.MoveCount();
		float resultCount03 = Move03.MoveCount();
		float resultCount04 = Move04.MoveCount();
		float resultCount05 = Move05.MoveCount();
		float resultCount06 = Move06.MoveCount();
		float resultCount07 = Move07.MoveCount();
		float resultCount08 = Move08.MoveCount();
		float resultCount09 = Move09.MoveCount();
		float resultCount10 = Move10.MoveCount();
		float resultCount11 = Move11.MoveCount();
		float resultCount12 = Move12.MoveCount();
		AllMoveCount += resultCount;
		AllMoveCount += resultCount01;
		AllMoveCount += resultCount02;
		AllMoveCount += resultCount03;
		AllMoveCount += resultCount04;
		AllMoveCount += resultCount05;
		AllMoveCount += resultCount06;
		AllMoveCount += resultCount07;
		AllMoveCount += resultCount08;
		AllMoveCount += resultCount09;
		AllMoveCount += resultCount10;
		AllMoveCount += resultCount11;
		AllMoveCount += resultCount12;
		FinalMoveCount += AllMoveCount;
		text.text = ((int)AllMoveCount).ToString ();
	}	

	void Update () {
		//何もしない
		/*GameControllerMain1 g1 = Game.GetComponent<GameControllerMain1> ();
		GameControllerMain01 g01 = Game.GetComponent<GameControllerMain01> ();
		GameControllerMain2 g02 = Game.GetComponent<GameControllerMain2> ();
		GameControllerMain03 g03 = Game.GetComponent<GameControllerMain03> ();
		GameControllerMain04 g04 = Game.GetComponent<GameControllerMain04> ();
		GameControllerMain05 g05 = Game.GetComponent<GameControllerMain05> ();
		GameControllerMain06 g06 = Game.GetComponent<GameControllerMain06> ();
		GameControllerMain07 g07 = Game.GetComponent<GameControllerMain07> ();
		GameControllerMain08 g08 = Game.GetComponent<GameControllerMain08> ();
		GameControllerMain09 g09 = Game.GetComponent<GameControllerMain09> ();
		GameControllerMain10 g10 = Game.GetComponent<GameControllerMain10> ();
		GameControllerMain11 g11 = Game.GetComponent<GameControllerMain11> ();*/
	}

	public static float finalMove()
	{
		return FinalMoveCount;
	}
}
