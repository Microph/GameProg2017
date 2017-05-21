﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character {
    public bool isDown = false;
    public bool isHoldingWater = false;
    public string up, down, left, right, skill;
    public float cooldown;
	public RawImage icon;
	public Text cooldownText;
    public bool triggerNormalSkill = false;
	private bool skillIsOnCooldown = false;
	private float cooldownTimer;
    Player player;

    //water skill section
    public GameObject waterBullet;


    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
		cooldownTimer = cooldown;
        player = GetComponent<Player>();
    }

    void FixedUpdate()
    {
        float h = 0, v = 0;
        if (Input.GetButton(up))
        {
            v++;
            facing = upF;
        }
        if(Input.GetButton(down))
        {
            v--;
            facing = downF;
        }
        if (Input.GetButton(right))
        { 
            h++;
            facing = rightF;
        }
        if (Input.GetButton(left))
        {
            h--;
            facing = leftF;
        }

        Move(h, v);
        if (Input.GetButtonDown(skill) && isHoldingWater)
        {
            shootWater();
            isHoldingWater = false;
        } else if (Input.GetButtonDown (skill) && !skillIsOnCooldown) {
            // trigger skill
            triggerNormalSkill = true;
			skillIsOnCooldown = true;
			icon.color = new Color (255, 0, 0);
            isDown = false;
        } else if (skillIsOnCooldown) {
			if (cooldownTimer <= 0) {
				cooldownTimer = cooldown;
				skillIsOnCooldown = false;
                icon.color = new Color(0, 255, 0);
            }
        }
  }
  
	public bool isOnCooldown() {
		return skillIsOnCooldown;
	}

	void Update(){
        if (skillIsOnCooldown)
            cooldownTimer -= Time.deltaTime;
        cooldownText.text = cooldownTimer.ToString ("F2");
    }

    void shootWater()
    {
        GameObject waterBulletObject = Instantiate(waterBullet, new Vector2(player.transform.position.x, player.transform.position.y - 1), Quaternion.identity) as GameObject;
        WaterBullet waterBulletInstance = waterBulletObject.GetComponent<WaterBullet>();
        if (player.facing == 0)
        { //left
            facing = player.facing;
            waterBulletObject.transform.Rotate(Vector3.forward * -90);
            waterBulletInstance.direction = leftF; 
        }
        else if (player.facing == 1)
        { //up
            facing = player.facing;
            waterBulletObject.transform.Rotate(Vector3.forward * -180);
            waterBulletInstance.direction = upF;
        }
        else if (player.facing == 2)
        { //right
            facing = player.facing;
            waterBulletObject.transform.Rotate(Vector3.forward * -270);
            waterBulletInstance.direction = rightF;
        }
        else if (player.facing == 3)
        { //down
            facing = player.facing;
            waterBulletInstance.direction = downF;
        }
    }
}
