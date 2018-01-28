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
	public float messageHour;
	public float messageMinute;
	public float messageSecond;
	float loopTime = 0f;
	public bool playing = false;
	public float messageTime = 0f;
	public bool messageEnd = false;
	public bool messagePlaying = false;
	

	void Start () {
		currentAudio = gameObject.GetComponent<AudioSource>();
		foreach(AudioClip audio in schedule){
			loopTime += audio.length;
		}
	}
	
	public bool Message(bool cont, bool play=true){
		if(message!=null && !messageEnd){
			if(ClockController.instance.hour>=messageHour &&
					ClockController.instance.minute>=messageMinute && 
					ClockController.instance.second>=messageSecond
				){	
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
						if(playing){
							if(currentAudio.clip!=message){
								currentAudio.Stop();
								currentAudio.clip = message;
							}
							if(cont){
								currentAudio.time = passedTime;
							}
							if(!currentAudio.isPlaying){
								Debug.Log("plaaaaaay");
								currentAudio.Play();
							}	
						}
						messagePlaying = true;
						return true;
					} else {
						Debug.Log("end____");
						RadioController.allowMap = true;
						messagePlaying = false;
						messageEnd = true;
						messageTime = message.length*5;
						if(play){
							Stop();
							Play();
						}
						return false;
					}
				}
		}
		return false;
	}
	// Update is called once per frame
	void Update () {
		if(playing){
			Message(false); 
			if(!currentAudio.isPlaying){
				if(messagePlaying){
					Debug.Log("end");
					messageEnd = true;
					messagePlaying = false;
					Stop();
					Play(false);
					return;
				}
				audioIndex++;
				if(audioIndex>=schedule.Length){
					audioIndex = 0;
				}
				currentAudio.clip = schedule[audioIndex];
				Debug.Log("play2");
				currentAudio.Play();
			}
			
		}
	}

	public void Play(bool msg = true){
		Debug.Log("play");
		//if(message==null){
		playing = true;
		if(msg){
			if(Message(true)){
				return;
			}
		}
		float actualTime = (ClockController.totalTime-messageTime)/5;
		//Debug.Log("loop:"+loopTime);
		if(ClockController.totalTime-messageTime>(loopTime*5)){
			actualTime = ((ClockController.totalTime-messageTime)%(loopTime*5))/5;
		}
		//Debug.Log("actual:"+actualTime);
		for(int i=0;i<schedule.Length;i++){
			AudioClip audio = schedule[i];
			audioIndex = i;
			if(actualTime<audio.length){
				//Debug.Log("actual: "+actualTime);
				currentAudio.Stop();
				currentAudio.clip = audio;
				currentAudio.time = actualTime;					
				currentAudio.Play();
				return;
			}
			actualTime -= audio.length;

		}	
		//}
	}

	public void Stop(){
		currentAudio.Stop();
		playing = false;
		
	}
}
