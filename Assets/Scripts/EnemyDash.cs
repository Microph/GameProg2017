using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDash : MonoBehaviour {
    public RawImage icon;
    public Text cooldownText;
    public static bool isDashing = false;
    public string dash;
    public float dashSpeed = 2.0f;
    public float dashDuration = 1f;
    bool skillIsOnCooldown = false;
    private float cooldownTimer;
    public float cooldown;

    const int leftF = 0, upF = 1, rightF = 2, downF = 3;
    Enemy enemyScript;
    Transform body;
    Vector3 movement;
    bool istouchingWall = false;
    float startDashTime = 0f;
    bool isTouchingCheat = false;

    void Awake()
    {
        enemyScript = GetComponent<Enemy>();
        body = GetComponent<Transform>();
        cooldownText.text = cooldown.ToString();
    }
	
	void FixedUpdate ()
    {
        if (!isDashing && !EnemyAttack.isAttacking && Input.GetKey(dash) && istouchingWall && !skillIsOnCooldown)
        {
            skillIsOnCooldown = true;
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

    void Update()
    {
        if (skillIsOnCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                cooldownTimer = cooldown;
                skillIsOnCooldown = false;
            }
            cooldownText.text = cooldownTimer.ToString("F2");
        }
    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.collider.tag == "preventCheat")
            isTouchingCheat = true;

        else if (coll.collider.tag == "Wall" && !isTouchingCheat)
            istouchingWall = true;
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider.tag == "preventCheat")
            isTouchingCheat = false;

        if (coll.collider.tag == "Wall")
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
        istouchingWall = false;
    }
}
