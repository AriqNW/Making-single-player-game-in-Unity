using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    Movement move;
    Animator anim;

    Collider2D platform;
    Collider2D player;

	// Use this for initialization
	void Start () {
        move = GameObject.Find("Player").GetComponent<Movement>();//memanggil script Movement yg ada di player
        platform = GetComponent<Collider2D>();
        player = GameObject.Find("Player").GetComponent<Collider2D>();
        anim = GameObject.Find("Player").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (move.isJump && player.transform.position.y > platform.transform.position.y + 3.5)//jika player lompat & tinggi lebih dr platform
        {
            platform.enabled = true;
        } else if (!move.isJump)
        {
            platform.enabled = false;
        }
        platTouch();
	}

    void platTouch()
    {
        if (platform.IsTouching(player))
        {
            anim.SetBool("isJump", false);
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                move.isJump = false;
                move.Jump();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                platform.enabled = false;
                anim.SetBool("isJump", true);
            }
        }
    }
}
