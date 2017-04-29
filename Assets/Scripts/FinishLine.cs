using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour {

    public Text[] timeText;

    int isDone = 0;
    float startTime;

    void Awake()
    {
        startTime = Time.time;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDone > 3)
            return;
        
        float timeSpent = Time.time - startTime;
        int minutes = (int)timeSpent / 60;
        int seconds = (int)timeSpent % 60;
        timeText[isDone].text = minutes.ToString() + " minutes " + seconds.ToString() + " seconds.";
        timeText[isDone].enabled = true;
        isDone++;
    }
}
