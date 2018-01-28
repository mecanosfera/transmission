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
	public float messageTime = 0f;

	void Start () {
		currentAudio = gameObject.GetComponent<AudioSource>();
		foreach(AudioClip audio in schedule){
			loopTime += audio.length;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(playing){
			if(message!=null && messageTime==0f){
				if(ClockController.instance.hour>=messageHour &&
					ClockController.instance.minute>=messageMinute && 
					ClockController.instance.second>=messageSecond
				){
					messageTime = message.length*5;
					float passedTime = 0f;
					if(ClockController.instance.hour>messageHour){
						passedTime += 3600;
					}
					if(ClockController.instance.minute>messageMinute){
						passedTime += ((ClockController.instance.minute-messageMinute)/5)*60;
					}
					if(ClockController.instance.second>messageSecond){
						passedTime += ((ClockController.instance.second-messageSecond)/5);
					}
					if(passedTime<message.length){
						currentAudio.Stop();
						currentAudio.clip = message;
						currentAudio.time = passedTime;
						currentAudio.Play();
						message = null;
					}
				}
			} 
			if(!currentAudio.isPlaying){
				audioIndex++;
				if(audioIndex>=schedule.Length){
					audioIndex = 0;
				}
				currentAudio.clip = schedule[audioIndex];
				currentAudio.Play();
			}
			
		}
	}

	public void Play(){
		if(message==null){
			float actualTime = ClockController.totalTime-messageTime;
			float musicTime = 0f;
			//Debug.Log("loop:"+loopTime);
			if(ClockController.totalTime-messageTime>(loopTime*5)){
				actualTime = (ClockController.totalTime-messageTime)%(loopTime*5);
			}
			audioIndex = 0;
			foreach(AudioClip audio in schedule){
				musicTime += audio.length*5;
				audioIndex++;
				if((actualTime<=musicTime)){
					currentAudio.Stop();
					currentAudio.clip = audio;
					currentAudio.time = (musicTime-actualTime)/5;					
					currentAudio.Play();
					playing = true;
					return;
				}
				
			}
			
		}
	}

	public void Stop(){
		if(message==null){
			currentAudio.Stop();
			playing = false;
		}
	}
}
