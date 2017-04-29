using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationArrow : MonoBehaviour {
    public Transform player, arrow, target;
    public float rotationOffset = 90f;

    void FixedUpdate () {
        // position
        Vector3 towardDir = (target.position - player.position).normalized;
        arrow.position = player.position + towardDir;

        // rotation
        float rotate = Vector3.Angle(new Vector3(1, 0, 0), towardDir);
        Vector3 cross = Vector3.Cross(new Vector3(1, 0, 0), towardDir);
        if (cross.z < 0)
            rotate = -rotate;

        arrow.rotation = Quaternion.Euler(0, 0, rotate - rotationOffset);
    }
}
