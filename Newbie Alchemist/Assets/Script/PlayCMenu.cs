using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayCMenu : MonoBehaviour {

    public void playButton()
    {
        SceneManager.LoadScene("contmenu");
    }
}
