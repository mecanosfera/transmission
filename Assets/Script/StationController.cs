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
	public bool Message(bool jump = true){
		if(message!=null && !messageEnd){
			//Debug.Log("1");
			
			if(!messagePlaying && ClockController.instance.hour==4 && ClockController.instance.minute==30){
				messagePlaying = true;
				//Debug.Log("2");
			}
			if(messagePlaying){
				//Debug.Log("3");
				float passedTime = 0f;
				passedTime = ((ClockController.instance.minute-30)*12) + ClockController.instance.second/5;
				if(passedTime>=message.length){
					Debug.Log("zzzzzzzzzzzzz");
					messageEnd = true;
					messageTime = message.length*5;
					messagePlaying = false;
					RadioController.allowMap = true;
					audioIndex = 2;
					return false;
				}
				if(playing){
					//Debug.Log("5");
					if(currentAudio.clip!=message){
						currentAudio.Stop();
						currentAudio.clip = message;
					}
					
					if(!currentAudio.isPlaying){
						Debug.Log("plaaaaaay ");
						currentAudio.time = passedTime;
						currentAudio.Play();
					}	
				}
				return true;
				
			}
			return false;

		}


		return false;
	}


	
	public bool Message2(bool cont, bool play=true){
		if(message!=null && !messageEnd){
			if(ClockController.instance.hour>=messageHour &&
					ClockController.instance.minute>=messageMinute && 
					ClockController.instance.second>=messageSecond
				){	
					float passedTime = 0f;
					if(ClockController.instance.hour>messageHour || ClockController.instance.minute>messageMinute){
						RadioController.allowMap = true;
						messagePlaying = false;
						messageEnd = true;
						messageTime = message.length*5;
						return false;
					}
					if(ClockController.instance.second>messageSecond){
						passedTime += ((ClockController.instance.second-messageSecond*5)/5);
					}
					
					if(passedTime<message.length){
						if(playing){
							if(currentAudio.clip!=message){
								currentAudio.Stop();
								currentAudio.clip = message;
							}
							if(cont){
								Debug.Log(passedTime);
								currentAudio.time = passedTime;
							}
							if(!currentAudio.isPlaying){
								Debug.Log("plaaaaaay "+currentAudio.time);
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
				/*if(messagePlaying){
					Debug.Log("end");
					messageEnd = true;
					messagePlaying = false;
					Stop();
					Play(false);
					return;
				}*/
				
				audioIndex++;
				Debug.Log(audioIndex);
				if(audioIndex>=schedule.Length){
					audioIndex = 0;
				}
				currentAudio.clip = schedule[audioIndex];
				Debug.Log("play|||");
				currentAudio.Play();
			}
			
		}
	}

	public void Play(bool msg = true){
		Debug.Log("play: "+audioIndex);
		//if(message==null){
		playing = true;
		if(msg){
			if(Message()){
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
				Debug.Log("ppp: "+audioIndex);				
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
