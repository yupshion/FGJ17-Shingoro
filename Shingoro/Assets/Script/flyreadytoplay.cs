using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class flyreadytoplay : MonoBehaviour {

    public void movereadytoplay()
    {
		AkSoundEngine.PostEvent("next", gameObject);
        SceneManager.LoadScene("readytoplay");
    }
}
