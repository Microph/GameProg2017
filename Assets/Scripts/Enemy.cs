using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public string xAxis, yAxis;

    Vector3 movement;
    Rigidbody2D playerRigidbody;
    
    void FixedUpdate()
    {
        float h = 0, v = 0;
        if (Input.GetAxisRaw(yAxis) > 0.3 || Input.GetAxisRaw(yAxis) < -0.3)
        {
            v += Input.GetAxisRaw(yAxis);
            if (v > 0)
                facing = upF;
            else
                facing = downF;
        }
           
        if (Input.GetAxisRaw(xAxis) > 0.3 || Input.GetAxisRaw(xAxis) < -0.3)
        {
            h += Input.GetAxisRaw(xAxis);
            if (h > 0)
                facing = rightF;
            else
                facing = leftF;
        }

        Move(h, v);
    }

}
