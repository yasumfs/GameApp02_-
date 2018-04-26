using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerMain01 : MonoBehaviour {

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

	public GameObject ClearText;
	public GameObject move;
	public GameObject next;
	public GameObject nextbuttom;
	public bool gameClear = false;
	public GameObject timer;
	public GameObject Cable;
	public GameObject ClearObj;
	private float ClearTime;

	public AudioSource audioSource;
	public AudioSource audioSource1;
	public AudioSource audioSource2;
	public GameObject ClearAudio;

	public GameObject obj1 ;
	public GameObject obj2 ;
	public GameObject obj3 ;
	public GameObject obj4 ;

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
					Move01 m01 =move.GetComponent<Move01>();
					m01.ClickCount++;
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
		DoCheck ();
		if (Input.GetMouseButtonDown (0)) {
			LeftDown ();
		}
	
	}

	public void DoCheck() {
		Vector2 pos = new Vector2 (434f, 149f);
		// 最初の移動方向
		int direction = kLeft;

		while (true) {
			// 現在のチェックポイントの確認
			//Debug.Log ("pos = " + pos);


			// 現在位置のパネルを取得する
			GameObject panel = GetPanel (pos);
			if (panel != null) {
				}

			// パネルがなければ、ゴール地点か、間違った場所に来ている
			if (panel == null) {
				// ゴール地点の座標（88, 456）と現在位置との距離を計算する
				float goalDist = (pos - new Vector2 (34f, 349f)).magnitude;
				// 距離が一定の距離以下であればゴールにたどり着いたのでクリア
				if (goalDist < 5f) {
					TimeController01 t = timer.GetComponent<TimeController01> ();
					t.time = false;
					gameClear = true;
					Animator cable = Cable.GetComponent<Animator> ();
					cable.enabled = true;
					Animator light = ClearObj.GetComponent<Animator> ();
					light.enabled = true;
					ClearTime += Time.deltaTime;
					ClearAudio.SetActive (true);
					if (ClearTime > 2) {
						ClearText.SetActive (true);
						nextbuttom.SetActive (true);
					}
					/*Animator p1 = obj1.GetComponent<Animator> ();
					p1.enabled = true;
					Animator p2 = obj2.GetComponent<Animator> ();
					p2.enabled = true;
					Animator p3 = obj3.GetComponent<Animator> ();
					p3.enabled = true;
					Animator p4 = obj4.GetComponent<Animator> ();
					p4.enabled = true;*/
				} else {
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
				//Animator p = panel.GetComponent<Animator> ();
				//p.enabled = false;
				//Debug.Log ("Cannot move...(1)");
				break;
			}

			// 現在位置と次のパネルがある方向を元に、次のパネルの位置を計算する
			pos = GetNextPosition (pos, direction);
			if (panel != null&&gameClear == true) {
				//panel.SetActive (false);
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
						if (dist <= 200f) {
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

	private void LeftDrag ()
	{
		//何もしない
	}

	private void LeftUp ()
	{
		//何もしない
	}

	Vector2 GetNextPosition(Vector2 currentPos, int nextDirection)
	{
		if (nextDirection == kUp) {
			return currentPos + new Vector2 (0, 200f);
		} else if (nextDirection == kDown) {
			return currentPos + new Vector2 (0, -200f);
		} else if (nextDirection == kLeft) {
			return currentPos + new Vector2 (-200f, 0f);
		} else if (nextDirection == kRight) {
			return currentPos + new Vector2 (200f, 0f);
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
		} else if (panelType == 5) {
			if (direction == kLeft) {
				return kDown;
			} else if (direction == kUp) {
				return kRight;
			}
			return -1;
		} else if (panelType == 6) {
			if (direction == kLeft) {
				return kLeft;
			} else if (direction == kRight) {
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
