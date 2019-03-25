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
    public float dashForce;
    public float dashTime = 1f;
    private float dashTimer = 0;
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
        if (rb.velocity.x > maxSpeed)
        {
            move = 0;
        }
        if (rb.velocity.x < -maxSpeed)
        {
            move = 0;
        }
        rb.AddForce(new Vector2(move, 0));

        
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
    void Dash() // skal gøres bedre
    {

        //dashTime
        dashTimer -= Time.deltaTime;
        if (dashTimer >= 0) rb.gravityScale = 0;
        else rb.gravityScale = 1;


        if (Input.GetAxisRaw("Horizontal")==1 && Input.GetButtonDown("Dash"))
        {
            rb.velocity = new Vector2(dashForce, 0);
            dashTimer = dashTime;
        }
        if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetButtonDown("Dash"))
        {
            rb.velocity = new Vector2(-dashForce, 0);
            dashTimer = dashTime;
        }
    }
    #endregion
}
