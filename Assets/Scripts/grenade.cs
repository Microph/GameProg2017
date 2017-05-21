using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour {
	const int maxGrenades = 1;
	int count = 0;
	GameObject []grenades =new GameObject[maxGrenades];

	public string throwButton;
	public GameObject grenadeObject;
	public GameObject explodeOject;
	public float throwDistance = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (throwButton)) {
			throwGrenade ();
		}
	}

	void throwGrenade(){
		if (count >= maxGrenades) {
			count = 0;
			Destroy (grenades [count]);
		}
			


		if (grenades [count] != null) {
			var item = (GameObject)Instantiate (explodeOject,grenades[count].transform.position,Quaternion.identity);
			explodeOject.SetActive(true);
			Destroy (item,0.5f);

		} else {
			var item = (GameObject) Instantiate(grenadeObject, transform.position, Quaternion.identity);
			grenades[count] = item;
			count++;

		}
			


	}
}
