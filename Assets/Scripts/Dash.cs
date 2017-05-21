using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {
    public static bool isDashing = false;
    public float dashSpeed = 6.0f;
    public float dashDuration = 0.2f;

    const int leftF = 0, upF = 1, rightF = 2, downF = 3;
    Player player;
    Transform body;
    Vector3 movement;
    float startDashTime = 0f;

    void Awake()
    {
        player = GetComponent<Player>();
        body = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (!isDashing && player.triggerNormalSkill)
        {
            player.triggerNormalSkill = false;
            beginDash();
        }

        else if (isDashing && Time.time - startDashTime < dashDuration)
        {
            player.isDown = false;
            body.Translate(movement * Time.deltaTime);
        }

        else if (isDashing)
        {
            finishDash();
        }

    }

    void beginDash()
    {
        player.enabled = false;
        isDashing = true;
        startDashTime = Time.time;

        //set dash vector to the facing direction
        switch (player.facing)
        {
            case leftF: movement.Set(-dashSpeed, 0, 0); break;
            case upF: movement.Set(0, dashSpeed, 0); break;
            case rightF: movement.Set(dashSpeed, 0, 0); break;
            case downF: movement.Set(0, -dashSpeed, 0); break;
            default: movement.Set(-dashSpeed, 0, 0); break;
        }
    }

    void finishDash()
    {
        player.enabled = true;
        isDashing = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        finishDash();
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        finishDash();
    }
}
