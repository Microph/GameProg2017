using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public GameObject desPortal;
    public bool isTPing = false;

    IEnumerator Teleport(GameObject playerObject, Character playerScript)
    {
        playerScript.enabled = false;
        yield return new WaitForSeconds(0.5f);
        playerObject.transform.position = desPortal.transform.position;
        playerScript.enabled = true;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player = other.gameObject;
        Character playerScript = player.GetComponent<Character>();
        if (!playerScript.ableToTP || isTPing)
            return;

        isTPing = true;
        playerScript.ableToTP = false;
        StartCoroutine(Teleport(player, playerScript));
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Character playerScript = other.GetComponent<Character>();
        if (isTPing)
        {
            playerScript.ableToTP = false;
            //Debug.Log("Set ableToTP: false");
        }
        else
        {
            playerScript.ableToTP = true;
            //Debug.Log("Set ableToTP: true");
        }
        isTPing = false;
    }
}