using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuneButtonController : MonoBehaviour {

	public RadioController radioController;
	bool turning = false;
	bool clicked = false;
	Vector3 startClickPosition;
	Vector3 lastScreenPosition;

	void Start () {
		lastScreenPosition = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if(clicked && Input.mousePosition!=startClickPosition){
			turning = true;
		}
		if(turning){
			Vector3 upAxis = new Vector3(0,0,-1);
			Vector3 mouseScreenPosition = Input.mousePosition;
			//set mouses z to your targets
			mouseScreenPosition.z = transform.position.z;
			mouseScreenPosition.x = mouseScreenPosition.x-lastScreenPosition.x;
			mouseScreenPosition.y = mouseScreenPosition.y-lastScreenPosition.y;
			Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
			Debug.Log("l: "+lastScreenPosition);
			Debug.Log("m: "+mouseWorldSpace);
			transform.LookAt(mouseWorldSpace, upAxis);
			//zero out all rotations except the axis I want
			transform.eulerAngles = new Vector3(0,0,-transform.eulerAngles.z);
			
			lastScreenPosition = mouseScreenPosition;//Input.mousePosition;
		}
	}

	void OnMouseDown(){
		//Debug.Log("down: "+transform.eulerAngles.z);
		if(radioController.on){
			startClickPosition = Input.mousePosition;
			clicked = true;
		}
	}

	void OnMouseUp(){
		//Debug.Log("up: "+transform.eulerAngles.z);
		if(radioController.on){
			turning = false;
			clicked = false;
		}
	}

	void OnMouseExit(){
		if(radioController.on){
			turning = false;
			clicked = false;
		}
	}
}
