using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoy : MonoBehaviour
{

    public float speed = 6f;    // Floating point variable to store the player's movement speed.
    //public string up, down, left, right;
    public string xAxis, yAxis;
    public int facing = 0;

    const int leftF = 0, upF = 1, rightF = 2, downF = 3;

    Vector3 movement;
    Rigidbody2D playerRigidbody;

    // Use this for initialization
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
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

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, v, 0f);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }

}
