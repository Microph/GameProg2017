using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inRangeHealingTarget : MonoBehaviour {
    public Text text;

	void Update () {
        text.text = "Players in range: " + HealRange.inRangeNumber.ToString();
	}
}
