using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour {
    const int leftF = 0, upF = 1, rightF = 2, downF = 3;
    public float bulletSpeed = 12f;
    public int direction = -1;

	void Update() {
		if(direction == leftF)
        {
            transform.Translate(new Vector2(0, -1) * Time.deltaTime * bulletSpeed);
        }
        else if (direction == upF)
        {
            transform.Translate(new Vector2(0, -1) * Time.deltaTime * bulletSpeed);
        }
        else if (direction == rightF)
        {
            transform.Translate(new Vector2(0, -1) * Time.deltaTime * bulletSpeed);
        }
        else if (direction == downF)
        {
            transform.Translate(new Vector2(0, -1) * Time.deltaTime * bulletSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("destroy!");
        Destroy(this.GetComponent<GameObject>(), 0.0f);
    }
}
