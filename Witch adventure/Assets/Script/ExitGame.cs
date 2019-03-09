using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour {

    public void exitButon()//method untuk tombol exit
    {
        Application.Quit();//akan quit game(tidak berpengaruh dalam editor)
    }
}
