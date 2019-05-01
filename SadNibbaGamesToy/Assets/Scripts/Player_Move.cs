using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    #region Refrences
    [Header("Input")]
    public KeyCode right;
    public KeyCode left;
    public KeyCode jump;
    public KeyCode dash;

    public Rigidbody2D rb;
    public Transform spawnPoint;
    public LayerMask groundLayer;
    public Animator animator;

    #endregion

    #region Variables
    
    float move;
    [Header("Walk")]
    [Tooltip("How fast the player can walk, not movement overall")]
    public float speed = 5;
    public float jumpForce = 20;
    [Header("Dash")]
    public float dashForce;
    [Tooltip("The time the player stays in the air before falling")]
    public float dashTime = 1f;
    private float dashTimer = 0;
    private bool faceingRight = true;
    [Tooltip("Time between available dashes")]
    public float dashCooldown = 5f;
    private float dashCooldownTimer = 0;

   private float defaultGravityScale;
   private Vector2 defaultScale;
    #endregion
    void Start()
    {
        transform.position = spawnPoint.position;
        defaultGravityScale = rb.gravityScale;
        defaultScale = transform.localScale;
    }

    private void Update()
    {
        //functions
        Walk();
        Dash();
        Jump();
    }


    #region Functions

    void Walk()
    {
        if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = defaultScale;
            animator.SetBool("Walking", true);
            faceingRight = true;
        }
        else if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-defaultScale.x, defaultScale.y);
            animator.SetBool("Walking", true);
            faceingRight = false;
        }
        else animator.SetBool("Walking", false);

    }
    void Jump()
    {
        if (Input.GetKeyDown(jump) && Groundcheck())
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
    bool Groundcheck()
    {
        return Physics2D.Raycast(transform.position, Vector2.down,0.6f,groundLayer);
    }
    void Dash()
    {
        dashTimer -= Time.deltaTime;
        dashCooldownTimer -= Time.deltaTime;

        if (dashTimer >= 0)
        {
            rb.gravityScale = 0;
            animator.SetBool("Dashing", true);
        }
        else
        {
            rb.gravityScale = defaultGravityScale;
            animator.SetBool("Dashing", false);
        }
        if (dashCooldownTimer <= 0) // Can only dash when DashCooldownTimer is over 0 or 0
        {
            // hvis man ser til x retning og trykker på "Dash" dasher man til x retning
            if (faceingRight && Input.GetKeyDown(dash))
            {
                rb.velocity = new Vector2(dashForce, 0);
                dashTimer = dashTime;
                dashCooldownTimer = dashCooldown;
            }
            if (!faceingRight && Input.GetKeyDown(dash))
            {
                rb.velocity = new Vector2(-dashForce, 0);
                dashTimer = dashTime;
                dashCooldownTimer = dashCooldown;
            }
        }
    }
    #endregion
}
