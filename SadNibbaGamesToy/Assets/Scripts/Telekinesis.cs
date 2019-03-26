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
    public Vector2 deadCenter = new Vector2(3, 3);
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

        // bruge deadCenter så at objectet står stille når musen er i midten
    }
    
}
