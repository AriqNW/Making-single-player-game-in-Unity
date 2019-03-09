using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour {
    GameObject Enemy;
    Rigidbody2D ergb;
    Transform trans;//untuk modifikasi posisi
    bool facingleft;
    int alive;
    public int score;
    Text text;

	// Use this for initialization
	void Start () {
        Enemy = GetComponent<GameObject>();
        ergb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        score = 0;
        text = GameObject.Find("Text").GetComponent<Text>();
        facingleft = true;
        alive = 3;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!facingleft)
        {
            trans.position += trans.right * 5 * Time.deltaTime;
        }
        else
        {
            trans.position -= trans.right * 5 * Time.deltaTime;
        }
        EnemyDead(alive);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "box" || coll.gameObject.tag == "Player" || coll.gameObject.tag == "arrow")
        {
            facingleft = !facingleft;
        }
        if(coll.gameObject.tag == "arrow")
        {
            alive -= 1;
        }
    }

    void EnemyDead(int alive)
    {
        if(alive == 0)
        {
            score += 10000000;
            text.text = "SCORE : " + score;
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameWin");
        }
    }
}
