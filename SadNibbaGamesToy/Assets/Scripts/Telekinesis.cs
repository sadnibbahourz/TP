using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour
{
    #region Refrences
    private Rigidbody2D rb;
    #endregion

    #region Variables
    public float acceleration = 1f;
    public float deadCenterWidth = 3f;
    public float maxSpeed = 5f;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMouseDrag()
    {
        float move = acceleration;
        if(rb.velocity.x > maxSpeed | rb.velocity.x < -maxSpeed)
        {
            move = 0;
        }

        if (Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, 0)).x < transform.position.x + deadCenterWidth && Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, 0)).x > transform.position.x - deadCenterWidth) // don't move if mouse is in the width
        {
            return;
        }else if(Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,0)).x > transform.position.x)
        {
            rb.AddForce(new Vector2(move, 0)* Vector2.right);
        }else if (Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, 0)).x < transform.position.x)
        {
            rb.AddForce(new Vector2(move, 0)* Vector2.left);
        }
        
    }
    
}
