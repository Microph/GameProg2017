﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 6f;    // Floating point variable to store the player's movement speed.
    public int facing = 0;
    public bool ableToTP = true;
    public int leftF = 0, upF = 1, rightF = 2, downF = 3;

    Vector3 movement;
    Rigidbody2D playerRigidbody;

    public void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, v, 0f);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }
}