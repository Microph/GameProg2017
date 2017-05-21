using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTPable : MonoBehaviour {
    public bool isAbleToTP = true;

    void OncollisionExit2D()
    {
        isAbleToTP = true;
    }
}
