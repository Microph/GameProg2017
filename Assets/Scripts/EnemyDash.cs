using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDash : MonoBehaviour {
    public static bool isDashing = false;
    public string dash;
    public float dashSpeed = 2.5f;
    public float dashDuration = 1f;

    const int leftF = 0, upF = 1, rightF = 2, downF = 3;
    Enemy enemyScript;
    Transform body;
    Vector3 movement;
    bool istouchingWall = false;
    float startDashTime = 0f;

    void Awake()
    {
        enemyScript = GetComponent<Enemy>();
        body = GetComponent<Transform>();
    }
	
	void Update ()
    {
        if (!isDashing && !EnemyAttack.isAttacking && Input.GetKey(dash) && istouchingWall)
        {
            beginDash();
        }

        else if(isDashing && Time.time - startDashTime < dashDuration)
        {
            body.Translate(movement * Time.deltaTime);
        }

        else if(isDashing)
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
        enemyScript.enabled = false;
        isDashing = true;
        GetComponent<CircleCollider2D>().isTrigger = true;
        startDashTime = Time.time;

        //set dash vector to the facing direction
        switch (enemyScript.facing)
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
        enemyScript.enabled = true;
        isDashing = false;
        GetComponent<CircleCollider2D>().isTrigger = false;
    }
}
