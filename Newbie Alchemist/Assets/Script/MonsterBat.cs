using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBat : MonoBehaviour {

    GameObject bat;
    Rigidbody2D ergb;
    Transform trans;
    bool up = true;

    [SerializeField]
    private float flySpeed;

    // Use this for initialization
    void Start () {
        bat = GetComponent<GameObject>();
        ergb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (up)
        {
            trans.position += trans.up * flySpeed * Time.deltaTime;
        }
        else
        {
            trans.position -= trans.up * flySpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            up = !up;
        }
    }
}