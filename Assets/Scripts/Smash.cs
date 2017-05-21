using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour
{
    private bool isCollideDetector = false;
    private bool isCollideSmashingWall = false;

    IEnumerator Stun(Player playerScript)
    {
        playerScript.enabled = false;
        yield return new WaitForSeconds(1);
        playerScript.enabled = true;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "smashDetect")
        {
            isCollideDetector = true;
        }
        if(coll.collider.tag == "smashingWall")
        {
            isCollideSmashingWall = true;
        }

        if (isCollideDetector && isCollideSmashingWall)
            StartCoroutine(Stun(GetComponent<Player>()));
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider.tag == "smashDetect")
        {
            isCollideDetector = false;
        }
        if (coll.collider.tag == "player")
        {
            isCollideSmashingWall = false;
        }
    }

}
