﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnController : MonoBehaviour {

	public RadioController radio;
	public Sprite turnedOn;
	public Sprite turnedOff;
	SpriteRenderer spriteR;
	void Start () {
		spriteR = gameObject.GetComponent<SpriteRenderer>();
		if(radio.on){
			Debug.Log(radio.on);
			spriteR.sprite = turnedOn;
		} else {
			spriteR.sprite = turnedOff;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if(radio.on){
			radio.TurnOn(false);	
			spriteR.sprite = turnedOff;
		} else {
			radio.TurnOn(true);
			spriteR.sprite = turnedOn;
		}
	}
}
