using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flytyurorial : MonoBehaviour {

    public void movetyutorial()
    {
		AkSoundEngine.PostEvent("next", gameObject);
        SceneManager.LoadScene("howtoplay");
    }
}
