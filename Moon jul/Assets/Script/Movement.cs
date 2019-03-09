using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public bool facingRight;
    public bool isJump;
    public int health;
    private Animator anim;

    [SerializeField]//untuk bisa mengeset di unity
    private float moveSpeed;

    [SerializeField]
    private float jumpHigh;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        facingRight = true;
        isJump = false;
        anim = GetComponent<Animator>();
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        float horizon = Input.GetAxis("Horizontal");//GetAxis = mengeset otomatis jika tekan kiri/a,diam,kanan/d langsung -1/0/1
        HandleMovement(horizon);
        Flip(horizon);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))//GetKeyDown = jika tombol ditekan, GetKeyUp = jika tombol dilepas
        {
            Jump();
        }
        PlayerDead(health);
    }

    void HandleMovement(float horizon)//untuk bisa jalan
    {
        rb2d.velocity = new Vector2(horizon * moveSpeed, rb2d.velocity.y);//mengeset velocity.x = horizon * moveSpeed, velocity.y tetap
        anim.SetFloat("runSpeed", Mathf.Abs(horizon));//mengeset anim player dengan angka absolute dari horizon (tidak boleh min)
    }

    void Flip(float horizon)//untuk membuat player bisa menghadap kanan/kiri
    {//!facingRight = (facingRight = false)
        if (horizon > 0 && !facingRight || horizon < 0 && facingRight)//jika tekan kanan hadap kiri || tekan kiri hadap kanan
        {
            facingRight = !facingRight;//membalikkan facingRight
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }

    public void Jump()//untuk bisa lompat
    {
        if (!isJump)
        {
            rb2d.AddForce(new Vector2(0f, jumpHigh));//0f = (x = 0)
            isJump = true;
            anim.SetBool("isJump", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//untuk membuat jika menyentuh benda tag ground atau box baru bisa jump lagi
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "box")
        {
            isJump = false;
            anim.SetBool("isJump", false);
        }
        if(collision.gameObject.name == "Enemy")
        {
            health -= 30;
        }
    }

    void PlayerDead(float health)
    {
        if(health < 0)
        {
            //Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}