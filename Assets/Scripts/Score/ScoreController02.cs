using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController02 : MonoBehaviour {
	private float AllTime = 0 ;
	public Text text;
	public static float FinalTime = 0;
	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text>();
		float resultTime = TimeController.PlusTime();
		float resultTime01 = TimeController01.PlusTime();
		float resultTime02 = TimeController2.PlusTime();
		float resultTime03 = TimeController03.PlusTime();
		float resultTime04 = TimeController04.PlusTime();
		float resultTime05 = TimeController05.PlusTime();
		float resultTime06 = TimeController06.PlusTime();
		float resultTime07 = TimeController07.PlusTime();
		float resultTime08 = TimeController08.PlusTime();
		float resultTime09 = TimeController09.PlusTime();
		float resultTime10 = TimeController10.PlusTime();
		float resultTime11 = TimeController11.PlusTime();
		float resultTime12 = TimeController12.PlusTime();
		AllTime += resultTime;
		AllTime += resultTime01;
		AllTime += resultTime02;
		AllTime += resultTime03;
		AllTime += resultTime04;
		AllTime += resultTime05;
		AllTime += resultTime06;
		AllTime += resultTime07;
		AllTime += resultTime08;
		AllTime += resultTime09;
		AllTime += resultTime10;
		AllTime += resultTime11;
		AllTime += resultTime12;
		FinalTime += AllTime;
		text.text = ((int)AllTime).ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		//何もしない
	}

	public static float Time()
	{
		return FinalTime;
	}
}
