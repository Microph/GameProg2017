using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heal : MonoBehaviour {
    public Collider2D healRange;
    public AudioClip skillSound;
    public AudioSource sfxSource;
    public SpriteRenderer halo;

    Player player;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    IEnumerator Halo()
    {
        player.enabled = false;
        halo.enabled = true;
        yield return new WaitForSeconds(0.5f);
        halo.enabled = false;
        player.enabled = true;
    }

    void Update()
    {
        if (player.triggerNormalSkill)
        {
            sfxSource.PlayOneShot(skillSound);
            heroesNeverDie();
            player.triggerNormalSkill = false;
        }
    }

    //check target this time
    void heroesNeverDie()
    {
        StartCoroutine(Halo());
        foreach (Player healingTarget in HealRange.inRangeTargets)
        {
            healingTarget.isDown = false;
			PlayerAllDead.count--;
        }
    }

}