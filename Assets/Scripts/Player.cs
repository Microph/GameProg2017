using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed = 6f;    // Floating point variable to store the player's movement speed.
    public string up, down, left, right, skill;
    public int facing = 0;
    public bool ableToTP = true;
	public float cooldown;
	public RawImage icon;
	public Text cooldownText;
	private bool skillIsOnCooldown = false;
	private float cooldownTimer;

    const int leftF = 0, upF = 1, rightF = 2, downF = 3;

    Vector3 movement;
    Rigidbody2D playerRigidbody;

    // Use this for initialization
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
		cooldownTimer = cooldown;
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
		} else if (skillIsOnCooldown) {
			cooldownTimer -= Time.deltaTime;
			if (cooldownTimer < 0) {
				cooldownTimer = cooldown;
				skillIsOnCooldown = false;
				icon.color = new Color (0, 255, 0);
			}
		}
  }
  
	public bool isOnCooldown() {
		return skillIsOnCooldown;
	}

	void Update(){
		cooldownText.text = cooldownTimer.ToString ();
	}

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, v, 0f);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }
}
