using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    #region Refrences
    public Rigidbody2D rb;
    public Transform spawnPoint;
    public LayerMask groundLayer;
    public Animator animator;

    #endregion

    #region Variables
    
    float move;
    [Header("Walk")]
    [Tooltip("How fast the player walks from 0 to maxspeed")]
    public float acceleration;
    [Tooltip("How fast the player can walk, not movement overall")]
    public float maxSpeed = 5;
    public float jumpForce = 20;
    [Header("Dash")]
    public float dashForce;
    [Tooltip("The time the player stays in the air before falling")]
    public float dashTime = 1f;
    private float dashTimer = 0;
    private bool faceingRight = true;
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
        move = Input.GetAxisRaw("Horizontal") * acceleration * Time.deltaTime;
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
            faceingRight = false;
            transform.localScale = new Vector2(-1, transform.lossyScale.y);
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            faceingRight = true;
            transform.localScale = new Vector2(1, transform.lossyScale.y);
        }
    }
    void Dash()
    {

        //dashTime
        dashTimer -= Time.deltaTime;
        if (dashTimer >= 0)
        {
            rb.gravityScale = 0;
            animator.SetBool("Dashing", true);
        }
        else
        {
            rb.gravityScale = 1;
            animator.SetBool("Dashing", false);
        }

        // hvis man ser til x retning og trykker på "Dash" dasher man til x retning
        if (faceingRight && Input.GetButtonDown("Dash"))
        {
            rb.velocity = new Vector2(dashForce, 0);
            dashTimer = dashTime;
        }
        if (!faceingRight && Input.GetButtonDown("Dash"))
        {
            rb.velocity = new Vector2(-dashForce, 0);
            dashTimer = dashTime;
        }
    }
    #endregion
}
