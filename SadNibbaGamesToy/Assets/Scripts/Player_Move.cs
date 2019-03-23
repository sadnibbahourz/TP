using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    #region refrences
    public Rigidbody2D rb;
    public Transform spawnPoint;
    public LayerMask groundLayer;
    public KeyCode right;
    public KeyCode left;
    #endregion

    #region Variabler
    float move;
    public float speed;
    public float maxSpeed = 5;
    public float jumpForce = 20;
    int leftTotalTimes = 0;
    int rightTotalTimes = 0;
    public float resetDoubletapTime = 0.2f;
    float doubletapTime = 0;
    public float dashForce;
    #endregion
    void Start()
    {
        transform.position = spawnPoint.position;
    }

    private void Update()
    {
        doubletapTime -= Time.deltaTime;
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

        if (Input.GetKeyDown(right))
        {
            rightTotalTimes += 1;
            doubletapTime = resetDoubletapTime;
        }
        if (Input.GetKeyDown(left))
        {
            leftTotalTimes += 1;
            doubletapTime = resetDoubletapTime;
        }
        if(doubletapTime <= 0)
        {
            rightTotalTimes = 0;
            leftTotalTimes = 0;
        }
        if(rightTotalTimes >= 2)
        {
            rb.velocity = new Vector2(dashForce, rb.velocity.y);
            rightTotalTimes = 0;
            leftTotalTimes = 0;
        }
        if (leftTotalTimes >= 2)
        {
            rb.velocity = new Vector2(-dashForce, rb.velocity.y);
            rightTotalTimes = 0;
            leftTotalTimes = 0;
        }
    }
    #endregion
}
