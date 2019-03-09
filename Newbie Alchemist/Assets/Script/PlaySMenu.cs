using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySMenu : MonoBehaviour {

    public void playButton()
    {
        SceneManager.LoadScene("startmenu");
    }
}
