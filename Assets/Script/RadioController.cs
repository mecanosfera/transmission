using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour {

	public GameObject display;
	public GameObject pointer;
	public GameObject tuneButton;
	public GameObject turnOnButton;
	public float startFrequency = 0f;
	public float frequency;
	public bool on = false;
	public GameObject[] stat;
	public StationController[] stations;
	public StationController currentStation;
	public AudioSource noiseSource;
	

	void Start () {
		frequency = startFrequency;
		stat = GameObject.FindGameObjectsWithTag("RadioStation");
		stations = new StationController[stat.Length];
		for(int i=0;i<stat.Length;i++){
			stations[i] = stat[i].GetComponent<StationController>();
		}
		currentStation = null; //stations[0].GetComponent<StationController>();
		noiseSource = gameObject.GetComponent<AudioSource>();
		
		
		//currentStation.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool ChangeStation(StationController station){
		if(frequency>=station.frequency-20 && frequency<=station.frequency+20){
			if(currentStation==null){
				currentStation = station;
				currentStation.Play();
				currentStation.currentAudio.volume = 0;
				//noiseSource.Stop();
			} else {
				if(frequency>=station.frequency-5 && frequency<=station.frequency+5){
					currentStation.currentAudio.volume = 1;
					noiseSource.Stop();
					noiseSource.volume = 1;
				} else {
					if(!noiseSource.isPlaying){
						noiseSource.Play();
					}
					
					noiseSource.volume = (Mathf.Abs(frequency-station.frequency)/100)*3;
					currentStation.currentAudio.volume += Mathf.Abs(frequency-station.frequency)/150; 
					Debug.Log(noiseSource.volume);
				}
			}
			return true;
		}	
		return false;
		
	}

	public void ChangeFrequency(float angle){
		if(angle<=90f || angle>=270f){
			pointer.transform.localRotation = Quaternion.Euler(0f, 0f, angle);
		}
		frequency = GetFrequency(angle);
		for(int i=0;i<stations.Length;i++){
			if(ChangeStation(stations[i])){
				return;
			}
		}
		if(currentStation!=null){
			Debug.Log("bbbb");
			currentStation.Stop();
			currentStation = null;
			noiseSource.volume = 1;
			noiseSource.Play();
		}
		
		//Debug.Log(angle+" -> "+GetFrequency(angle));
	}

	

	public void TurnOn(bool radioOn){
		if(radioOn){
			on = true;
			Play();
		} else {
			on = false;
			Stop();
		}
	}

	public void Play(){
		if(currentStation!=null){
			currentStation.Play();	
		} else {
			noiseSource.Play();
		}
	}

	public void Stop(){
		if(currentStation!=null){
			currentStation.Stop();
		}
		noiseSource.Stop();
	}

	public float GetFrequency(float angle){
		float ret;
		if(angle<160f){
			ret = 90f-angle;
			if(ret<0f){
				ret = 0f;
			}
			return ret;
		}
		ret = 90f+(360f-angle);
		if(ret>180f){
			ret = 180f;
		}
		return ret;
	}

	
}
