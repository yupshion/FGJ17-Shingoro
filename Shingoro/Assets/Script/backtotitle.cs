using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtotitle : MonoBehaviour {

	void Awake(){
		//AkSoundEngine.PostEvent("BGM_title", gameObject);
		//SceneManager.sceneLoaded += OnSceneLoaded;

	}

    public void moveTitle()
    {

		AkSoundEngine.PostEvent("back", gameObject);
		//SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("Title");
        
    }

	private void OnSceneLoaded (Scene scene, LoadSceneMode sceneMode){
		//AkSoundEngine.PostEvent("BGM_title", gameObject);

		//Debug.Log (scene.buildIndex);//sceneの番号はscene.buildIndexで分かる
	}
}
