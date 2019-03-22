using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    #region refrences
    public Rigidbody2D rb;
    public Transform spawnPoint;
    public LayerMask groundLayer;
    #endregion

    #region Variabler
    float move;
    public float speed;
    public float maxSpeed = 5;
    public float jumpForce = 20;
    #endregion
    void Start()
    {
        transform.position = spawnPoint.position;
    }

    
    void FixedUpdate()
    {
        Walk();
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        if (Groundcheck())
        {
            Jump();
        }
    }


    #region Functions

    void Walk()
    {
        move = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        rb.AddForce(new Vector2(move, 0));

        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }
    }
    bool Groundcheck()
    {
        return Physics2D.Raycast(transform.position, Vector2.down,0.6f,groundLayer);
    }
    #endregion
}
