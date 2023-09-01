using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] SpriteRenderer spRender;

    Rigidbody2D rb2D;

    bool grounded = true;
    public bool moving = false;
    float speed = 7f;
    float jumpPower = 700f;
    float fallMutiplier = 7.5f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerMove();
    }

    void playerMove()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            moving = true;
            spRender.flipX = false;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            moving = true;
            spRender.flipX = true;
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) moving = false;
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) moving = false;

        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb2D.AddForce(transform.up * jumpPower);
            grounded = false;
        }
        if (rb2D.velocity.y < 0)    //掉落物理增強
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMutiplier - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground") grounded = true;
    }

    public bool movingState()   //被呼叫用
    {
        if (moving) return true;
        else return false;
    }

}
