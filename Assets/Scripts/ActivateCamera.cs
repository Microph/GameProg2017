using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Display.displays[1].Activate();
    }
}
