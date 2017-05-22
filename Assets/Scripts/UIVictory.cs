using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIVictory : MonoBehaviour {

	public RawImage screenFaderPlayer;
	public Text victoryTextPlayer;
	public RawImage screenFaderEnemy;
	public Text defeatTextEnemy;
	private float Fade = 0f;
	private float delayCount = 0f;
	private bool phase = false;

	// Use this for initialization
	void Start () {
        screenFaderPlayer.color = new Color(0f, 0f, 0f, 0f);
        victoryTextPlayer.color = new Color(1f, 1f, 1f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
		if (delayCount > 7f) {
			Fade += .2f * Time.deltaTime;
			screenFaderPlayer.color = new Color (0f, 0f, 0f, Fade);
			victoryTextPlayer.color = new Color (1f, 1f, 1f, Fade);
			screenFaderEnemy.color = new Color (0f, 0f, 0f, Fade);
			defeatTextEnemy.color = new Color (1f, 1f, 1f, Fade);
			delayCount += Time.deltaTime;
			if (Input.anyKeyDown && delayCount > 15f)
				Application.Quit ();
		} else if (phase) {
			delayCount += Time.deltaTime;
		} else if (!phase && EnemyDead.enemyIsDead) {
			phase = true;
			victoryTextPlayer.text = "Victory";
			defeatTextEnemy.text = "Defeat";
		}
	}
}
