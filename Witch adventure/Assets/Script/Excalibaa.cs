using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Excalibaa : MonoBehaviour {

    GameObject excalibaa;
    Rigidbody2D ergb;
    Transform trans;
    bool fly = true;

    // Use this for initialization
    void Start () {
        excalibaa = GetComponent<GameObject>();
        ergb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (fly)
        {
            trans.position += trans.up * 1 * Time.deltaTime;//akan berpindah keatas secepat 1*waktu
        }
        else
        {
            trans.position -= trans.up * 1 * Time.deltaTime;//akan berpindah keatas secepat 1*waktu
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")//jika tersentuh gameObject bernama Player
        {
            Destroy(this.gameObject);//menghapus gameObject dari game
            SceneManager.LoadScene("WinGame");//berpindah ke scene bernama WinGame

        }
        if (coll.gameObject.tag == "ground")//jika tersentuh gameObject bernama ground
        {
            fly = !fly;
        }
    }
}
