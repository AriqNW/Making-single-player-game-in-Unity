using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour {

    public Vector2 arrowMove;
    Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        if (GameObject.Find("Player").gameObject.GetComponent<Movement>().facingRight)
        {
            arrowMove = new Vector2(arrowMove.x, arrowMove.y);
        } else
        {
            arrowMove = new Vector2(-arrowMove.x, arrowMove.y);
        }
        rb2d.velocity = arrowMove;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
