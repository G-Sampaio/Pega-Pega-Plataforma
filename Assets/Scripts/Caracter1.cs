using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caracter1 : MonoBehaviour
{
    public float Speed;
    public string test;
    public float JumpForce;
    private Rigidbody2D rig;
    public bool isJumping;
    public bool doubleJump;


    void Start()
    {
       rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();


    }
    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            doubleJump = true;
            }
            else
            {
                if (doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
    }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8) 
        {
            isJumping = true;
        }
    }
}
