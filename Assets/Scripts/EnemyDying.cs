using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDying : MonoBehaviour {

	public Enemy enemy;
	private float fadeOut = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (true) {
			enemy.GetComponent<SpriteRenderer> ().color = new Color(1f,1f,1f,fadeOut -= .2f * Time.deltaTime);
		}
	}
}
