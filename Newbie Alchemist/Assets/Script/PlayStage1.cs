using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayStage1 : MonoBehaviour {

    public void playButton()
    {
        SceneManager.LoadScene("stage1");
    }
}
