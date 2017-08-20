using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour {

	public float GameTime = 60f;
	public Text GameTimeText;

	public Image CountTime;
	public bool loop;
	public float countTime;

	[SerializeField]
	private GameObject P1Win;
	[SerializeField]
	private GameObject P2Win;
	[SerializeField]
	private GameObject mochi;
	[SerializeField]
	private GameObject oshingoro;

	private bool finished;
	private bool oshingoroed;
	private float oshingoroTime;


	private Vector3 posP1 = new Vector3(Screen.width /2 , Screen.height /4, 0);
	private Vector3 posP2 = new Vector3(Screen.width /2 , Screen.height * 3 /4, 0);

	// Use this for initialization
	void Start () {
		finished = false;
		oshingoroed = false;
		oshingoroTime = 3;
		//GameTime;
		GameTimeText.text = "" + GameTime.ToString();
		AkSoundEngine.PostEvent("start", gameObject);
		AkSoundEngine.PostEvent("BGM_battle", gameObject);
		countTime = GameTime;

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
		} else if(!oshingoroed){
			oshingoroTime -= 1f * Time.deltaTime;

			if (oshingoroTime < 0) {
				mochi.SetActive (false);
				oshingoro.SetActive (true);
				oshingoroed = true;
			}
		}

		if (loop) {


			CountTime.fillAmount -= 1.0f / countTime * Time.deltaTime;

		}

	}


	void CheckResult(){
		Transform mochiPos = GameObject.Find ("Mochi").GetComponent<Transform>();
        //シーンを重ねる
        SceneManager.LoadScene("Workshop", LoadSceneMode.Additive);

        if (mochiPos.position.y > 0 ){
			P1Win.SetActive (true);

		}else{
			P2Win.SetActive (true);

		}

	}
}
