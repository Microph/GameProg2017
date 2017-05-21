using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {
    const int maxTraps = 1;

    public Transform player;
    public GameObject trap;
    public string markButton;
    
    int count = 0;
    GameObject[] traps = new GameObject[maxTraps];

    void Update()
    {
        if (Input.GetKeyDown(markButton))
        {
            placeTrap();
        }
    }

    void placeTrap()
    {
        if (count >= maxTraps)
            count = 0;

        var t = (GameObject) Instantiate(trap, player.transform.position, Quaternion.identity);
        if(traps[count] != null)
            Destroy(traps[count]);

        traps[count] = t;
        count++;
    }
}
