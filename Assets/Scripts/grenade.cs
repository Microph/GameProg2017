using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : IsTPable {
    public AudioClip skillSound;
    public AudioClip bombSound;
    public AudioSource sfxSource;
    const int maxGrenades = 1;
	int count = 0;
	GameObject []grenades = new GameObject[maxGrenades];
	public Player p;
	string skill;
	public GameObject grenadeObject;
	public GameObject explodeOject;
	private bool skillIsOnCooldown = false;
	private float cooldownTimer;
	float cooldown;
	// Use this for initialization
	void Start () {
		cooldown = p.cooldown;
		skill = p.skill;
		cooldownTimer = cooldown;
			
	}
	int num =0;
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown (skill) && !p.isHoldingWater) {
			Debug.Log (skillIsOnCooldown+" "+num);

			if (!skillIsOnCooldown ) {
				
				Debug.Log ("throw " + num);
                throwGrenade();

				if (num > 0) {
					skillIsOnCooldown = true;
					num = 0;
				}
				else
				num++;
			}
			// trigger skill


		} else if (skillIsOnCooldown) {
			cooldownTimer -= Time.deltaTime;
			if (cooldownTimer < 0) {
				cooldownTimer = cooldown;
				skillIsOnCooldown = false;
			}
		}
	}

	void throwGrenade(){
		if (count >= maxGrenades) {
			count = 0;
			Destroy (grenades [count]);
		}
			


		if (grenades [count] != null) {
            sfxSource.PlayOneShot(bombSound); 
            var item = (GameObject)Instantiate (explodeOject,grenades[count].transform.position,Quaternion.identity);
			explodeOject.SetActive(true);
			Destroy (item,0.5f);

		} else {
            sfxSource.PlayOneShot(skillSound);
            var item = (GameObject) Instantiate(grenadeObject, transform.position, Quaternion.identity);
			grenades[count] = item;
			count++;

		}
			
	}
}
