using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class go_tutorial : MonoBehaviour {

	public Image img;
	public string [] imglist = new string [4];
	public int i;

	// Use this for initialization
	void Start () {
		i = 0;
		imglist[0] ="tt1";
		imglist[1] ="tt2";
		imglist[2] ="tt3";
		imglist[3] ="tt4";
		img.sprite = Resources.Load<Sprite> (imglist[0]);
	}

	// Update is called once per frame
	void Update () {

	}

	public void next(){
		i++;
		if (i == imglist.Length) i = 0;
		img.sprite = Resources.Load<Sprite> (imglist[i]);
	}

	public void previous(){
		i--;
		if (i < 0) i = imglist.Length -1 ;
		img.sprite = Resources.Load<Sprite> (imglist[i]);
	}
}