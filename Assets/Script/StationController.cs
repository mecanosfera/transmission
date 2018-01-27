using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour {

	
	public AudioClip[] schedule;
	public AudioClip message;
	public AudioSource currentAudio;
	public string stationName;
	public float frequency;
	int audioIndex = 0;
	float messageHour;
	float messageMinute;
	float messageSecond;
	float loopTime = 0f;
	public bool playing = false;

	void Start () {
		currentAudio = gameObject.GetComponent<AudioSource>();
		foreach(AudioClip audio in schedule){
			loopTime += audio.length;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(message!=null){

		} else {

		}
	}

	public void Play(){
		if(message==null){
			float actualTime = ClockController.totalTime;
			float musicTime = 0f;
			//Debug.Log("loop:"+loopTime);
			if(ClockController.totalTime>loopTime){
				actualTime = ClockController.totalTime%loopTime;
				Debug.Log("actual: "+actualTime);
			}
			audioIndex = 0;
			foreach(AudioClip audio in schedule){
				musicTime += audio.length;
				Debug.Log("audo len "+audio.length);
				audioIndex++;
				if(actualTime<=musicTime){
					Debug.Log(musicTime+" "+actualTime);
					currentAudio.Stop();
					currentAudio.clip = audio;
					currentAudio.time = musicTime-actualTime;					
					currentAudio.Play();
					return;
				}
				
			}
			
		}
	}

	public void Stop(){
		if(message==null){
			currentAudio.Stop();
		}
	}
}
