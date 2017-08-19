using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {

    float GameTime;
    public Text GameTimeText;

    // Use this for initialization
    void Start () {
        GameTime = 60f;
        GameTimeText.text = "" + GameTime.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        GameTime -= 1f * Time.deltaTime;
        GameTimeText.text = ((int)GameTime).ToString();

    }
}
