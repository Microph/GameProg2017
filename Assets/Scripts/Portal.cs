using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public GameObject desPortal;
    public bool isTPing = false;

    IEnumerator Teleport(GameObject playerObject, Player playerScript)
    {
        playerScript.enabled = false;
        yield return new WaitForSeconds(2);
        playerObject.transform.position = desPortal.transform.position;
        playerScript.enabled = true;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player = other.gameObject;
        Player playerScript = player.GetComponent<Player>();
        if (!playerScript.ableToTP || isTPing)
            return;

        isTPing = true;
        playerScript.ableToTP = false;
        StartCoroutine(Teleport(player, playerScript));
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Player playerScript = other.GetComponent<Player>();
        if (isTPing)
        {
            playerScript.ableToTP = false;
            Debug.Log("Set ableToTP: false");
        }
        else
        {
            playerScript.ableToTP = true;
            Debug.Log("Set ableToTP: true");
        }
        isTPing = false;
    }
}