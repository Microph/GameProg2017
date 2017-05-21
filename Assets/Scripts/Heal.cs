using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {
    public Collider2D healRange;
    public AudioClip skillSound;
    public AudioSource sfxSource;

    Player player;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    IEnumerator Halo()
    {
        player.enabled = false;
        Component halo = healRange.GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
        yield return new WaitForSeconds(0.5f);
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
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
        }
    }

}