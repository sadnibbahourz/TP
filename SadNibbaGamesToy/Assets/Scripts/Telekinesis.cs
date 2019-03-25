using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour
{
    #region Refrences
    public Rigidbody2D rb;
    #endregion

    #region Variables
    public float acceleration = 1f;
    #endregion
    private void OnMouseDrag()
    {
        if(Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,0)).x > transform.position.x)
        {
            rb.AddForce(new Vector2(acceleration, 0)* Vector2.right);
        }
        if (Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, 0)).x < transform.position.x)
        {
            rb.AddForce(new Vector2(acceleration, 0)* Vector2.left);
        }
    }

}
