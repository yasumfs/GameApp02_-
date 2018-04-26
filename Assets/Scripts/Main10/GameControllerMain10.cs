﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerMain10 : MonoBehaviour {
	const int kUp = 0;
	const int kDown = 1;
	const int kRight = 2;
	const int kLeft = 3;

	private GameObject srcObj;
	private GameObject destObj;
	private Vector2 srcPos;
	private Vector2 destPos;
	private float moveTime;
	private bool isMoving = false;
	public GameObject Cable;
	public GameObject Cable2;
	public GameObject ClearObj;
	public GameObject ClearObj2;
	public GameObject Fan;

	public GameObject ClearText;
	public GameObject move;
	public bool gameClear = false;
	public GameObject next;
	public GameObject nextbuttom;
	public GameObject timer;
	private bool Clear = false;
	private bool Clear2 = false;
	private float ClearTime;

	public AudioSource audioSource;
	public AudioSource audioSource1;
	public AudioSource audioSource2;
	public GameObject ClearAudio;

	private const float kTileMoveTime = 0.3f;

	enum GameState {
		Start,
		Play,
	}

	GameState gameState;

	void Start ()
	{
		Time.timeScale = 1;
		gameState = GameState.Play;
	}

	void Update (){
		if (gameState == GameState.Start ) {
			return;
		}
		if (!gameClear) {
			if (isMoving) {
				moveTime -= Time.deltaTime;
				if (moveTime <= 0f) {
					moveTime = 0f;
					isMoving = false;
					SetTileColorUnselected (srcObj);
					SetTileColorUnselected (destObj);
					//移動回数
					Move10 move10 =move.GetComponent<Move10>();
					move10.ClickCount++;
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
		if (Input.GetMouseButtonDown (0)) {
			LeftDown ();
		}
		DoCheck ();
		DoCheck1 ();
		if (Clear == true&&Clear2 == true) {
			TimeController10 time = timer.GetComponent<TimeController10> ();
			time.time = false;
			gameClear = true;
			Animator cable = Cable.GetComponent<Animator> ();
			cable.enabled = true;
			Animator cable2 = Cable2.GetComponent<Animator> ();
			cable2.enabled = true;
			Animator fan = Fan.GetComponent<Animator> ();
			fan.enabled = true;
			ClearObj.SetActive (true);
			ClearObj2.SetActive (true);
			ClearAudio.SetActive (true);
			ClearTime += Time.deltaTime;
			if (ClearTime > 2) {
				ClearText.SetActive (true);
				nextbuttom.SetActive (true);
			}
		}
	}

	public void DoCheck() {
		Vector2 pos = new Vector2 (516f, 407f);

		// 最初の移動方向
		int direction = kLeft;

		while (true) {
			// 現在のチェックポイントの確認
			//Debug.Log ("pos = " + pos);
			// 現在位置のパネルを取得する
			GameObject panel = GetPanel (pos);

			// パネルがなければ、ゴール地点か、間違った場所に来ている
			if (panel == null) {
				// ゴール地点の座標（88, 456）と現在位置との距離を計算する
				float goalDist = (pos - new Vector2 (66f, 407f)).magnitude;
				float goalDist2 = (pos - new Vector2 (66f, 71f)).magnitude;
				// 距離が一定の距離以下であればゴールにたどり着いたのでクリア
				if (goalDist < 10f || goalDist2 < 10f) {
					Clear = true;
				} else {
					Clear = false;
					//Debug.Log ("Cannot move...(2)");
				}
				break;
			}

			// パネルの種類を数値として取得する
			int type = GetPanelType (panel);

			// パネルの種類を元に、次のパネルがあるはずの位置を取得する
			direction = GetNextDirection (type, direction);

			// 取得に失敗した場合にはマイナスの値が返ってくるので、たどり着かない
			if (direction < 0) {
				//Debug.Log ("Cannot move...(1)");
				Clear = false;
				break;
			}

			// 現在位置と次のパネルがある方向を元に、次のパネルの位置を計算する
			pos = GetNextPosition (pos, direction);
			if (panel != null&&gameClear == true) {
				panel.SetActiveRecursively (true);
			}
		}
	}

	public void DoCheck1(){
		Vector2 pos2 = new Vector2 (516f, 71f);

		// 最初の移動方向
		int direction = kLeft;

		while (true) {
			// 現在のチェックポイントの確認
			//Debug.Log ("pos2 = " + pos2);
			// 現在位置のパネルを取得する
			GameObject panel = GetPanel (pos2);
			if (panel == null) {
				float goalDist = (pos2 - new Vector2 (66f, 407f)).magnitude;
				float goalDist2 = (pos2 - new Vector2 (66f, 71f)).magnitude;
				if (goalDist < 10f || goalDist2 < 10f) {
					Clear2 = true;
				} else {
					Clear2 = false;
					//Debug.Log ("Cannot move...(2-1)");
				}
				break;
			}

			// パネルの種類を数値として取得する
			int type = GetPanelType (panel);

			// パネルの種類を元に、次のパネルがあるはずの位置を取得する
			direction = GetNextDirection (type, direction);

			// 取得に失敗した場合にはマイナスの値が返ってくるので、たどり着かない
			if (direction < 0) {
				Clear2 = false;
				//Debug.Log ("Cannot move...(1-1)");
				break;
			}
			pos2 = GetNextPosition (pos2, direction);
			if (panel != null&&gameClear == true) {
				panel.SetActiveRecursively (true);
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

	private void LeftDown ()
	{
		Vector3 tapPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0f);
		if (!gameClear) {
			// 移動元のオブジェクトを選択する
			if (srcObj == null) {
				Collider2D col = Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (tapPoint));
				if (col != null) {
					srcObj = col.gameObject;
					SetTileColorSelected (srcObj);
					audioSource2.Play();
					//holdObj.transform.position = Camera.main.ScreenToWorldPoint(tapPoint);
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
						if (dist <= 120f) {
							moveTime = kTileMoveTime;
							SetTileColorSelected (destObj);
							isMoving = true;
							audioSource1.Play();
						} else {
							// 距離のチェックに失敗したら選択を取り消す
							SetTileColorUnselected (srcObj);
							srcObj = null;
							audioSource.Play();
						}
					} else {
						// 移動元と移動先が同一であれば選択を取り消す
						SetTileColorUnselected (srcObj);
						srcObj = null;
						audioSource.Play();
					}
				}
			}
		}
	}

	Vector2 GetNextPosition(Vector2 currentPos, int nextDirection)
	{
		if (nextDirection == kUp) {
			return currentPos + new Vector2 (0, 112f);
		} else if (nextDirection == kDown) {
			return currentPos + new Vector2 (0, -112f);
		} else if (nextDirection == kLeft) {
			return currentPos + new Vector2 (-112f, 0f);
		} else if (nextDirection == kRight) {
			return currentPos + new Vector2 (112f, 0f);
		}
		return new Vector2 (-1000f, -1000f);
	}

	int GetNextDirection(int panelType, int direction)
	{
		if (panelType == 1) {
			if (direction == kUp) {
				return kUp;
			} else if (direction == kDown) {
				return kDown;
			}
			return -1;
		} else if (panelType == 2) {
			if (direction == kUp) {
				return kLeft;
			} else if (direction == kRight) {
				return kDown;
			}
			return -1;
		} else if (panelType == 3) {
			if (direction == kLeft) {
				return kUp;
			} else if (direction == kDown) {
				return kRight;
			}
			return -1;
		} else if (panelType == 4) {
			if (direction == kRight) {
				return kUp;
			} else if (direction == kDown) {
				return kLeft;
			}
			return -1;
		} else if (panelType == 5){
			if(direction == kLeft){
				return kDown;
			} else if(direction == kUp){
				return kRight;
			}
			return -1;
		} else if (panelType == 6){
			if(direction == kLeft){
				return kLeft;
			} else if(direction == kRight){
				return kRight;
			}
			return -1;
		} else {
			//Debug.Log ("Unknown panel type: " + panelType);
		}
		return -1;
	}

	int GetPanelType(GameObject panel)
	{
		string name = panel.name;
		return int.Parse (name.Substring (6));
	}

	GameObject GetPanel(Vector2 pos)
	{
		RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero);
		if (hit.collider) {
			GameObject obj = hit.collider.gameObject;
			if (obj.name.StartsWith ("panel")) {
				return obj;
			}
		}
		return null;
	}

	public void BeginGame()
	{
		gameState = GameState.Start;
	}

	public void StartGame()
	{
		gameState = GameState.Play;
	}
}
