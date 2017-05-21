using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class go_story : MonoBehaviour {

	public Image img;
	public string [] imglist = new string [10];
	public int i;

	// Use this for initialization
	void Start () {
		i = 0;
		imglist[0] ="t1";
		imglist[1] ="t2";
		imglist[2] ="t3";
		imglist[3] ="t4";
		imglist[4] ="t5";
		imglist[5] ="t6";
		imglist[6] ="tt1";
		imglist[7] ="tt2";
		imglist[8] ="tt3";
		imglist[9] ="tt4";
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

