using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVictory : MonoBehaviour {

	public RawImage screenFader;
	public Text victoryText;
	private float Fade = 0f;
	private float delayCount = 0f;
	private bool phase = false;

	// Use this for initialization
	void Start () {
        screenFader.color = new Color(0f, 0f, 0f, 0f);
        victoryText.color = new Color(1f, 1f, 1f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
		if (delayCount > 7f) {
			Fade += .2f * Time.deltaTime;
			screenFader.color = new Color (0f, 0f, 0f, Fade);
			victoryText.color = new Color (1f, 1f, 1f, Fade);
			delayCount += Time.deltaTime;
			if (Input.anyKeyDown && delayCount > 15f)
				Application.Quit ();
		} else if (phase) {
			delayCount += Time.deltaTime;
		} else if (!phase && EnemyDead.enemyIsDead) {
			phase = true;
		}
	}
}
