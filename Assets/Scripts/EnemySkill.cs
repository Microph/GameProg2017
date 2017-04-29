using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkill : MonoBehaviour {
    const int leftF = 0, upF = 1, rightF = 2, downF = 3;
    
    public string skill;
    public float dashSpeed = 2.5f;
    public float dashDuration = 1f;

    Player playerScript;
    Transform body;
    Vector3 movement;
    bool istouchingWall = false;
    bool isDashing = false;
    float startDashTime = 0f;

    void Awake()
    {
        playerScript = GetComponent<Player>();
        body = GetComponent<Transform>();
    }
	
	void Update ()
    {
        if (!isDashing && Input.GetKey(skill) && istouchingWall)
        {
            beginDash();
        }

        else if(isDashing && Time.time - startDashTime < dashDuration)
        {
            body.Translate(movement * Time.deltaTime);
        }

        else
        {
            finishDash();
        }

	}

    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.collider.tag == "Wall")
        {
            istouchingWall = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        istouchingWall = false;
    }

    void beginDash()
    {
        playerScript.enabled = false;
        isDashing = true;
        GetComponent<CircleCollider2D>().isTrigger = true;
        startDashTime = Time.time;

        //set dash vector to the facing direction
        switch (playerScript.facing)
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
        playerScript.enabled = true;
        isDashing = false;
        GetComponent<CircleCollider2D>().isTrigger = false;
    }
}
