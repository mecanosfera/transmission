using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour {

	
	public AudioSource[] schedule;
	public AudioSource message;
	AudioSource currentAudio;
	int audioIndex = 0;
	float messageHour;
	float messageMinute;
	float messageSecond;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(message!=null){

		} else {

		}
	}
}
