using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {

	float GameTime;
	public Text GameTimeText;

	[SerializeField]
	private GameObject P1Win;
	[SerializeField]
	private GameObject P2Win;
	private bool finished;

	private Vector3 posP1 = new Vector3(Screen.width /2 , Screen.height /4, 0);
	private Vector3 posP2 = new Vector3(Screen.width /2 , Screen.height * 3 /4, 0);

	// Use this for initialization
	void Start () {
		finished = false;
		GameTime = 60f;
		GameTimeText.text = "" + GameTime.ToString();
	}
	
	// Update is called once per frame
	void Update () {

		if (!finished) {

			GameTime -= 1f * Time.deltaTime;
			GameTimeText.text = ((int)GameTime).ToString ();

			if (GameTime < 0) {

				finished = true;
				CheckResult ();
			}
		}

	}


	void CheckResult(){
		Transform mochiPos = GameObject.Find ("Mochi").GetComponent<Transform>();
		if(mochiPos.position.y > 0 ){
			P1Win.SetActive (true);

		}else{
			P2Win.SetActive (true);

		}

	}
}
