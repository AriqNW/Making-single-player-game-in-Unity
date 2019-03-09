using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollision : MonoBehaviour {
    GameObject arrow;
    GameObject player;
    Collider2D acol;
    Transform trans;

	// Use this for initialization
	void Start () {
        acol = GetComponent<Collider2D>();
        trans = GetComponent<Transform>();
        arrow = GetComponent<GameObject>();
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(trans.position.x > player.transform.position.x + 0.5f ||
            trans.position.x < player.transform.position.x - 0.5f)
        {
            acol.enabled = true;
        }
	}

    void OnCollisionEnter2D (Collision2D coll)
    {
        if(coll.gameObject.tag == "box" || coll.gameObject.name == "Enemy")//jika ketemu tag box/nama Enemy
        {
            Destroy(this.gameObject);//destroy arrow
        }
    }
}
