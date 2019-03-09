using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    private float x = 5f;//bergerak sebanyak hitungan f
    private float y = 0f;

    private Rigidbody2D rb2d;
    private GameObject player;
    public Movement move;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        move = player.GetComponent<Movement>();

        rb2d.velocity = !move.facingRight ? new Vector2(-x, y) : new Vector2(x, y);//apakah player hadap kiri ? jika iya : tidak (if-then-else)
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
