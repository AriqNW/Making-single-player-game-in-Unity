using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    GameObject ghost;
    Rigidbody2D ergb;
    Transform trans;
    bool up = true;

    [SerializeField]
    private float flySpeed;

    // Use this for initialization
    void Start () {
        ghost = GetComponent<GameObject>();
        ergb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
    }
    
	// Update is called once per frame
	void Update () {
        if (up)
        {
            trans.position += trans.up * flySpeed * Time.deltaTime;//akan berpindah keatas secepat flySpeed*waktu
        }
        else
        {
            trans.position -= trans.up * flySpeed * Time.deltaTime;//akan berpindah kebawah secepat flySpeed*waktu
        }
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")//jika tersentuh gameObject bernama ground
        {
            up = !up;
        }
    }
}
