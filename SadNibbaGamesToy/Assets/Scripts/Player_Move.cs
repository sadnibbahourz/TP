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
    float doubleckickTime = 0.25f;
    #endregion
    void Start()
    {
        transform.position = spawnPoint.position;
    }

    
    void FixedUpdate()
    {
        Walk();
        FlipPlayer();
        Dash();
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
    void FlipPlayer()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector2(-1, transform.lossyScale.y);
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector2(1, transform.lossyScale.y);
        }
    }
    void Dash()
    {

        //doubleClick to dash
    }
    #endregion
}
