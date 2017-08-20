using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flyMainGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	//	AkSoundEngine.PostEvent("BGM_title", gameObject);

    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void movescene() {
	//	AkSoundEngine.PostEvent("next", gameObject);
        SceneManager.LoadScene("GameMain");
    }
}
