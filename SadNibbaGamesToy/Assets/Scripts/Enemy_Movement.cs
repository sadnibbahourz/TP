using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    #region variables

    public float speed = 5;

    private bool movingRight = false;

    public float maxSpeed = 5;

    #endregion

    #region references

    public Rigidbody2D rb;

    #endregion

  

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.velocity.x >= maxSpeed | rb.velocity.x <= -maxSpeed)

        Walk();
    }

    #region functions
    bool GroundCheck()
    {
        return Physics2D.Raycast(transform.position,new Vector2(1,-1));
    }
    
    void Walk()
    {
        rb.AddForce(new Vector2(speed, 0));
    }

    #endregion
}
