using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	private GameObject srcObj;
	private GameObject destObj;
	private Vector2 srcPos;
	private Vector2 destPos;
	private float moveTime;
	private bool isMoving = false;
	private bool gameClear = false;
	public GameObject text;

	private const float kTileMoveTime = 0.3f;

	public GameObject Main;
	public GameObject PlayButton;

	public string[] scenarios; // シナリオを格納する
	public Text uiText;	// uiTextへの参照を保つ

	int currentLine = 0; // 現在の行番号

	public AudioSource audioSource;
	public AudioSource audioSource1;
	public AudioSource audioSource2;

	void Start () {
		Time.timeScale = 1;
		TextUpdate();
	}

	void Update () {
		if (gameClear) {
			if (isMoving) {
				moveTime -= Time.deltaTime;
				if (moveTime <= 0f) {
					moveTime = 0f;
					isMoving = false;
					SetTileColorUnselected (srcObj);
					SetTileColorUnselected (destObj);
				}
				srcObj.transform.position = Vector2.Lerp (srcPos, destPos, (kTileMoveTime - moveTime) / kTileMoveTime);
				destObj.transform.position = Vector2.Lerp (destPos, srcPos, (kTileMoveTime - moveTime) / kTileMoveTime);
				if (!isMoving) {
					srcObj = null;
					destObj = null;
				}
				return;
			}
		}
		if (currentLine == 5) {
			gameClear = true;
			Main.SetActive (true);
			PlayButton.SetActive (true);
			text.SetActive (false);
		}
		if (!gameClear) {
			if (currentLine < scenarios.Length && Input.GetMouseButtonDown (0)) {
				TextUpdate ();
			}
		}
		if (gameClear) {
			if (Input.GetMouseButtonDown (0)) {
				LeftDown ();
			}
		}
	}

	private void SetTileColorUnselected(GameObject obj)
	{
		SpriteRenderer renderer = obj.GetComponent<SpriteRenderer> ();
		Color color = renderer.color;
		color.r = 1.0f;
		color.g = 1.0f;
		renderer.color = color;
	}


	private void SetTileColorSelected(GameObject obj)
	{
		SpriteRenderer renderer = obj.GetComponent<SpriteRenderer> ();
		Color color = renderer.color;
		color.r = 0.76f;
		color.g = 0.76f;
		renderer.color = color;
	}

	void TextUpdate()
	{
		// 現在の行のテキストをuiTextに流し込み、現在の行番号を一つ追加する
		uiText.text = scenarios[currentLine];
		currentLine ++;
	}

	private void LeftDown ()
	{
		Vector3 tapPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0f);
		if (gameClear) {
			// 移動元のオブジェクトを選択する
			if (srcObj == null) {
				Collider2D col = Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (tapPoint));
				if (col != null) {
					srcObj = col.gameObject;
					SetTileColorSelected (srcObj);
					audioSource1.Play();
				}
			}
			// 移動先のオブジェクトを選択する
			else {
				Collider2D col = Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (tapPoint));
				if (col != null) {
					if (col.gameObject != srcObj) {
						// 移動先が見つかった
						destObj = col.gameObject;
						srcPos = srcObj.transform.position;
						destPos = destObj.transform.position;
						float dist = (destPos - srcPos).magnitude;

						// 距離のチェック
						if (dist <= 200f) {
							moveTime = kTileMoveTime;
							SetTileColorSelected (destObj);
							isMoving = true;
							audioSource.Play();
						} else {
							// 距離のチェックに失敗したら選択を取り消す
							SetTileColorUnselected (srcObj);
							srcObj = null;
							audioSource2.Play();
						}
					} else {
						// 移動元と移動先が同一であれば選択を取り消す
						SetTileColorUnselected (srcObj);
						srcObj = null;
						audioSource2.Play();
					}
				}
			}
		}
	}
}
