using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character {
    public bool isDown = false;
    public string up, down, left, right, skill;
    public float cooldown;
	public RawImage icon;
	public Text cooldownText;
	private bool skillIsOnCooldown = false;
	private float cooldownTimer;

    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
		cooldownTimer = cooldown;
        Debug.Log(cooldownTimer);
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
		if (Input.GetButtonDown (skill) && !skillIsOnCooldown) {
            // trigger skill
			skillIsOnCooldown = true;
			icon.color = new Color (255, 0, 0);
            isDown = false;
        } else if (skillIsOnCooldown) {
			cooldownTimer -= Time.deltaTime;
			if (cooldownTimer < 0) {
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
		cooldownText.text = cooldownTimer.ToString ("F2");
	}
}
