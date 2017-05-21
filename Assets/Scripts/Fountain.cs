using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour {
    public bool isOnCooldown = false;
    public float fountainCooldownDuration = 5;

    float currentCooldownTime = 0;
    Animator fountainAnimator;

    void Awake()
    {
        fountainAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if(isOnCooldown)
        {
            currentCooldownTime -= Time.deltaTime;
            if (currentCooldownTime <= 0)
            {
                fountainAnimator.SetTrigger("cooldownEnd");
                isOnCooldown = false;
                currentCooldownTime = 0;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "player" && !isOnCooldown)
        {
            if (coll.gameObject.GetComponent<Player>().isDown)
                return;

            fountainAnimator.SetTrigger("getWater");
            currentCooldownTime = fountainCooldownDuration;
            isOnCooldown = true;
            coll.gameObject.GetComponent<Player>().isHoldingWater = true;
        }
    }
}
