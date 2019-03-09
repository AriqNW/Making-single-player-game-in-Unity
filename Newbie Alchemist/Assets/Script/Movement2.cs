using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement2 : MonoBehaviour
{

    private bool isDead = false;
    private Rigidbody2D rb2d;
    float horizon = 1f;

    [SerializeField]
    private float fastSpeed;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * fastSpeed);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "monster")
        {
            SceneManager.LoadScene("lose1");
        } else if (coll.gameObject.tag == "light")
        {
            SceneManager.LoadScene("win1");
        }
    }
}