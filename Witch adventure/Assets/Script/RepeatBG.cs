using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour {

    private BoxCollider2D groundCollider;
    private float groundHorizontalLenght;

	// Use this for initialization
	void Start () {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLenght = groundCollider.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < -groundHorizontalLenght)//jika posisi x lebih kecil dari -groundHorizontalLenght
        {
            RepositionBackground();
        }
	}

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLenght * 2f, 0);//untuk menentukan koordinat groundoffset
        transform.position = (Vector2)transform.position + groundOffset;//posisi akan berpindah sejauh posisi sekarang + groundoffset
    }
}