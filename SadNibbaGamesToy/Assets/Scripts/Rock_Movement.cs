﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Movement : MonoBehaviour
{
    private Vector3 offset;

    void OnMouseDown()
    {

        offset = gameObject.transform.position -
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.y, 10.0f));

    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.y, 10.0f);
    }

    void Update()
    {
        
    }
}
