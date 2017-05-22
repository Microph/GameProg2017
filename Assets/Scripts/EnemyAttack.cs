using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour {
    public RawImage icon;
    public Text cooldownText;
    public static bool isAttacking = false;
    public string attack;
    public Collider2D attackRange;
    bool skillIsOnCooldown = false;
    private float cooldownTimer;
    public float cooldown;

    Enemy enemyScript;

    void Awake()
    {
        enemyScript = GetComponent<Enemy>();
        cooldownTimer = cooldown;
    }

    IEnumerator Attacking(Enemy enemyScript)
    {
        isAttacking = true;
        AttackRange.attackRangeAnimator.SetTrigger("attacking");
        yield return new WaitForSeconds(0.5f);
        finishAttack();

        enemyScript.enabled = false;
        yield return new WaitForSeconds(1.25f); //brief self stun
        enemyScript.enabled = true;
    }

    void Update()
    {
        if (skillIsOnCooldown)
            cooldownTimer -= Time.deltaTime;
        cooldownText.text = cooldownTimer.ToString("F2");

        if (!isAttacking && Input.GetKey(attack) && !EnemyDash.isDashing && !skillIsOnCooldown)
        {
            skillIsOnCooldown = true;
            StartCoroutine(Attacking(enemyScript));
        }

        else if (skillIsOnCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                cooldownTimer = cooldown;
                skillIsOnCooldown = false;
            }
        }
    }


    //check target this time
    void finishAttack()
    {
        foreach(Player attackingTarget in AttackRange.inRangeTargets)
        {
            attackingTarget.isDown = true;
        }
        isAttacking = false;
    }
    
}
