using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smooth_Camera : MonoBehaviour
{
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public Vector2 clamp;
    public float clampup;

    void FixedUpdate ()
    {
        if (target)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

            

        }
        if (transform.position.x <= clamp.x)
        {
            transform.position = transform.position = new Vector3(clamp.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= clamp.y)
        {
            transform.position = transform.position = new Vector3(clamp.y, transform.position.y, transform.position.z);
        }
        if (transform.position.y <= clampup)
        {
            transform.position = new Vector3(transform.position.x, clampup, transform.position.z);
        }
    }


}
