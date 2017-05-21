using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public string up, down, left, right;
  
    Vector3 movement;
    Rigidbody2D playerRigidbody;

    void FixedUpdate()
    {
        float h = 0, v = 0;
        if (Input.GetButton(up))
        {
            v++;
            facing = upF;
        }
        if(Input.GetButton(down))
        {
            v--;
            facing = downF;
        }
        if (Input.GetButton(right))
        { 
            h++;
            facing = rightF;
        }
        if (Input.GetButton(left))
        {
            h--;
            facing = leftF;
        }

        Move(h, v);
    }
    
}
