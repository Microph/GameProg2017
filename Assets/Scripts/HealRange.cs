using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealRange : MonoBehaviour {
    public static List<Player> inRangeTargets = new List<Player>();
    public static int inRangeNumber = 0;

    void Update()
    {
        inRangeNumber = inRangeTargets.Count;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "player")
            inRangeTargets.Add(coll.GetComponent<Player>());
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "player")
            inRangeTargets.Remove(coll.GetComponent<Player>());
    }
}
