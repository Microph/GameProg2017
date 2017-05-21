using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public static bool isAttacking = false;
    public string attack;
    public Collider2D attackRange;

    Enemy enemyScript;

    void Awake()
    {
        enemyScript = GetComponent<Enemy>();
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
        if (!isAttacking && Input.GetKey(attack) && !EnemyDash.isDashing)
        {
            StartCoroutine(Attacking(enemyScript));
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
