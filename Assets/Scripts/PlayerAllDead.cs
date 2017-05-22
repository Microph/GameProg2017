using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAllDead : MonoBehaviour {

	public static uint count = 0;
	public RawImage screenFaderPlayer;
	public Text playerDefeatText;
	public RawImage screenFaderEnemy;
	public Text enemyVictoryText;
	private float Fade = 0f;
	private float delayCount = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (count == 4) {
			Debug.Log ("wtf");
			if (delayCount > 7f) {
				if (Input.anyKeyDown)
					Application.Quit();
			} else {
				playerDefeatText.text = "Defeat";
				enemyVictoryText.text = "Victory";
				delayCount += Time.deltaTime;
				Fade += 0.2f * Time.deltaTime;
				screenFaderEnemy.color = new Color (0f, 0f, 0f, Fade);
				enemyVictoryText.color = new Color (1f, 1f, 1f, Fade);
				screenFaderPlayer.color = new Color (0f, 0f, 0f, Fade);
				playerDefeatText.color = new Color (1f, 1f, 1f, Fade);
			}
		}
	}
}
