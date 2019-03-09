using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {

	public void playButton()
    {
        SceneManager.LoadScene("scene");//mengeload scene bernama scene
    }
}
