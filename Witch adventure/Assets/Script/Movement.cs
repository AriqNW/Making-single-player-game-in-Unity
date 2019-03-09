using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private bool isDead = false;
    private Rigidbody2D rb2d;
    float horizon = 1f;
    private Animator anim;

    [SerializeField]
    private float fastSpeed;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            HandleMovement(horizon);//memanggil method
        }
    }

    void HandleMovement(float horizon)
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))//jika user menekan tombol RightArrow
        {
            rb2d.velocity = new Vector2(fastSpeed, rb2d.velocity.y);
            anim.SetFloat("fast", Mathf.Abs(horizon));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))//jika user menekan tombol LeftArrow
        {
            rb2d.velocity = new Vector2(-fastSpeed, rb2d.velocity.y);
            anim.SetFloat("stop", Mathf.Abs(horizon));
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))//jika user menekan tombol UpArrow
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x,fastSpeed);
            anim.SetFloat("stop", Mathf.Abs(horizon));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))//jika user menekan tombol DownArrow
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x,-fastSpeed);
            anim.SetFloat("fast", Mathf.Abs(horizon));
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "enemy")//jika menyentuh gameObject bernama enemy
        {
            Destroy(this.gameObject);//menghapus gameObject dari game
            SceneManager.LoadScene("FailGame");//berpindah ke scene bernama FailGame
        }
    }
}