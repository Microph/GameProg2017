using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public string xAxis, yAxis;
    public int health = 3;
    
    protected override void Awake()
    {
        base.Awake();
    }

	bool isTrigger = false;
	IEnumerator DisableScript ()
	{
		if (!isTrigger) {
			isTrigger = true;

			this.enabled = false;
			yield return new WaitForSeconds(2.0f);
			this.enabled = true;
			isTrigger = false;
            spriteRenderer.color = originalColor;
        }

	}

	public void EnemyStun(){
		StartCoroutine(DisableScript());
	}

    void FixedUpdate()
    {
        float h = 0, v = 0;
        if (Input.GetAxisRaw(yAxis) > 0.3 || Input.GetAxisRaw(yAxis) < -0.3)
        {
            v += Input.GetAxisRaw(yAxis);
            if (v > 0)
            {
                facing = upF;
                spriteRenderer.sprite = sprites[0];
            }
            else
            {
                facing = downF;
                spriteRenderer.sprite = sprites[1];
            }
        }
           
        if (Input.GetAxisRaw(xAxis) > 0.3 || Input.GetAxisRaw(xAxis) < -0.3)
        {
            h += Input.GetAxisRaw(xAxis);
            if (h > 0)
            {
                facing = rightF;
                spriteRenderer.sprite = sprites[2];
                spriteRenderer.flipX = true;
            }
            else
            {
                facing = leftF;
                spriteRenderer.sprite = sprites[2];
                spriteRenderer.flipX = false;
            }
        }

        Move(h, v);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "bullet")
        {
            health -= 1;
            if (health > 0)
            {
                spriteRenderer.color = Color.red;
                StartCoroutine(DisableScript());
            }
            else
            {
                EnemyDead.enemyIsDead = true;
                spriteRenderer.color = Color.black;
                GetComponent<Enemy>().enabled = false;
                GetComponent<EnemyAttack>().enabled = false;
                GetComponent<EnemyDash>().enabled = false;
            }
        }
    }
}
