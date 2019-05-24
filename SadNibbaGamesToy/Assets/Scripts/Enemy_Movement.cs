using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    #region variables

    public float speed = 5;
    public float maxSpeed = 5;
    public float WallSightDis;
    public float groundDetectiondis;
    public float standTime = 2;

    private bool faceingRight = true;
    private bool standing = true;
    private float standTimer = 0;
    #endregion

    #region references

    public Rigidbody2D rb;

    public LayerMask Player;
    public LayerMask Ground;

    #endregion

  

    void Awake()
    {
        if (rb == null)
         //rb = GetComponent<Rigidbody2D>();

        //random direction
        if (Mathf.Round(Random.value) == 1)
            faceingRight = true;
        else faceingRight = false;
    }
    

    void FixedUpdate()
    {
        if(rb.velocity.x <= maxSpeed || rb.velocity.x >= -maxSpeed)
        Walk();

        flipEnemy();
    }

    #region functions
    
    
    void Walk()
    {
        if (!GroundCheck() && !standing)
        {
            standing = true;
            standTimer = standTime;
            if (standTimer <= 0)
                faceingRight = !faceingRight;
        }
           
        if(faceingRight && !standing)
        rb.AddForce(new Vector2(speed, 0));
        if (!faceingRight && !standing)
            rb.AddForce(new Vector2(-speed, 0));
    }

    void flipEnemy()
    {
        if (faceingRight)
            transform.localScale = new Vector2(1, 1);
        else
            transform.localScale = new Vector2(-1, 1);
    }

    #endregion
    #region Raycasts
    bool GroundCheck()
    {
        if (faceingRight)
        {
            Debug.DrawRay(transform.position + new Vector3(groundDetectiondis, 0), Vector2.down, Color.red);
            return Physics2D.Raycast(transform.position + new Vector3(groundDetectiondis, 0), Vector2.down, Ground);
        }
        else
        {
            Debug.DrawRay(transform.position + new Vector3(-groundDetectiondis, 0), Vector2.down, Color.red);
            return Physics2D.Raycast(transform.position + new Vector3(-groundDetectiondis, 0), Vector2.down, Ground);
        }
    }
    bool PlayerDetection()
    {
        if(faceingRight)
        return Physics2D.Raycast(transform.position, Vector2.right,Player);
        else return Physics2D.Raycast(transform.position, Vector2.left,Player);
    }
    bool WallDetection()
    {
        if(faceingRight)
        return Physics2D.Raycast(transform.position, Vector2.right, WallSightDis, Ground);
        else return Physics2D.Raycast(transform.position, Vector2.left, WallSightDis, Ground);
    }
    #endregion
}
