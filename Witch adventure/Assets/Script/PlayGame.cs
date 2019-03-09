using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {

	public void playButton()//method untuk tombol play
    {
        SceneManager.LoadScene("Ingame");//berpindah ke scene bernama Ingame
    }
}
