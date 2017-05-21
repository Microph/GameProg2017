using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public GameObject desPortal;
    public bool isTPing = false;

    IEnumerator Teleport(GameObject playerObject, Character playerScript)
    {
        playerScript.enabled = false;
        yield return new WaitForSeconds(0.0f);
        playerObject.transform.position = desPortal.transform.position;
        playerScript.enabled = true;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "bullet" || other.tag == "grenade")
        {
            IsTPable bullet = other.GetComponent<IsTPable>();
            if (bullet.isAbleToTP)
            {
                bullet.isAbleToTP = false;
                other.transform.position = desPortal.transform.position;
            }
            return;
        }
        GameObject character = other.gameObject;
        Character characterScript = character.GetComponent<Character>();
        if (!characterScript.ableToTP || isTPing)
            return;

        isTPing = true;
        characterScript.ableToTP = false;
        StartCoroutine(Teleport(character, characterScript));
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "bullet" || other.tag == "grenade")
            return;

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