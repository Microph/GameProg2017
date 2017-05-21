using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collision){
		Debug.Log ("OnTriggerEnter2D");
		if (collision.gameObject.name == "enemy") {
			Enemy e = collision.gameObject.GetComponent<Enemy>();
			e.EnemyStun ();


		}
	}

}
