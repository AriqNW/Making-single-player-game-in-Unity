using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement1 : MonoBehaviour {

    private Rigidbody2D rb2d;
    public bool facingRight;
    public bool isJump;
    private Animator anim;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float jumpHigh;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        facingRight = true;
        isJump = false;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float horizon = Input.GetAxis("Horizontal");
        HandleMovement(horizon);
        Flip(horizon);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
    }

    void HandleMovement(float horizon)
    {
        rb2d.velocity = new Vector2(horizon * moveSpeed, rb2d.velocity.y);
        anim.SetFloat("runSpeed", Mathf.Abs(horizon));
    }

    void Flip(float horizon)
    {
        if (horizon > 0 && !facingRight || horizon < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }

    public void Jump()
    {
        if (!isJump)
        {
            rb2d.AddForce(new Vector2(0f, jumpHigh));
            isJump = true;
            anim.SetBool("isJump", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isJump = false;
            anim.SetBool("isJump", false);
        }
        if (collision.gameObject.tag == "monster")
        {
            SceneManager.LoadScene("lose");
        } else if (collision.gameObject.tag == "light")
        {
            SceneManager.LoadScene("win");
        }
    }
}
