using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AllScoreController : MonoBehaviour {
	public Text text;
	private float score = 0;
	private float timer = 0;
	private bool count = false;
	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text> ();
	}
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 0) {
			if (count == false) {
				float resultMoveScore = ScoreController.finalMove ();
				float resultTimeScore = ScoreController02.Time ();
				score += (resultTimeScore - resultMoveScore);
				if (score <= 0) {
					score = 1;
				}
				int intScore = (int)score;
				intScore *= 100;
				text.text = (intScore).ToString ();
				count = true;
			}
		}
	}
}
