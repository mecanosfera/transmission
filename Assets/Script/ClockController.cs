using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour {

	
	public GameObject pointerHour;
	public GameObject pointerMinute;
	public GameObject pointerSecond;
	public GameObject dayPeriod;

	public float hour;
	public float minute;
	public float second;
	public bool am = false;
	public static bool timeJump = false;
	private const float hoursToDegrees = 360f / 12f;
    private const float minutesToDegrees = 360f / 60f;
    private const float secondsToDegrees = 360f / 60f;
	



	void Start () {
		hour = 4f;
		minute = 20f;
		second = 0f;
		//pointerHour.transform.
	}
	
	// Update is called once per frame
	void Update () {
		if(ClockController.timeJump){
			SetTime(10);
		} else {
			SetTime(Time.deltaTime);
		}
		
		
		pointerHour.transform.localRotation = Quaternion.Euler(0f, 0f, hour * -hoursToDegrees);
        pointerMinute.transform.localRotation = Quaternion.Euler(0f, 0f, minute * -minutesToDegrees);
        pointerSecond.transform.localRotation = Quaternion.Euler(0f, 0f, second * -secondsToDegrees);
		
	}

	public void SetTime(float sec){
		second += sec;
		if(second>=60f){
			second = 0f;
			minute++;
		}
		if(minute>=60f){
			minute = 0;
			hour++;
		}
		if(hour>=12f){
			hour = 0f;
			am = !am;
		}
	}

	void OnMouseDown(){
		ClockController.timeJump = true;	
	}

	void OnMouseUp(){
		ClockController.timeJump = false;
	}

	void OnMouseOver(){
		//Debug.Log("highlight!");
	}

	void OnMouseExit(){
		ClockController.timeJump = false;
	}

	
}
