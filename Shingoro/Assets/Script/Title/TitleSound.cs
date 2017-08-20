using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AkSoundEngine.PostEvent("BGM_title", gameObject);
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnSceneLoaded (Scene scene, LoadSceneMode sceneMode){
		//SceneManager.sceneLoaded += OnSceneLoaded;
		//AkSoundEngine.PostEvent("BGM_title", gameObject);

		//Debug.Log (scene.buildIndex);//sceneの番号はscene.buildIndexで分かる
	}
}
