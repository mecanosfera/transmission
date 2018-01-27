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
		/*if(clicked && Input.mousePosition!=startClickPosition){
			turning = true;
		}
		if(turning){
			if(transform.eulerAngles.z>1){
				Vector3 upAxis = new Vector3(0,0,-1);
				Vector3 mouseScreenPosition = Input.mousePosition;
				//set mouses z to your targets
				mouseScreenPosition.z = transform.position.z;
				mouseScreenPosition.x = mouseScreenPosition.x-transform.position.x;
				mouseScreenPosition.y = mouseScreenPosition.y-transform.position.y;
				Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
				transform.LookAt(mouseWorldSpace, upAxis);
				transform.eulerAngles = new Vector3(0,0,-transform.eulerAngles.z);
				Debug.Log("eu: "+transform.eulerAngles);
			}
		}*/
	}

	public void Rotate(Vector3 pos){
		if(radioController.on){
			//float angleZ = transform.eulerAngles.z;
			//Debug.Log("b:"+transform.eulerAngles.z);
			if((transform.eulerAngles.z>=0f && transform.eulerAngles.z<=90f) || (transform.eulerAngles.z<=360f && transform.eulerAngles.z>=270f)){
				Vector3 upAxis = new Vector3(0,0,1);
				Vector3 mouseScreenPosition = Input.mousePosition;
				mouseScreenPosition.z = transform.position.z;
				Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
				transform.LookAt(mouseWorldSpace, upAxis);
				float angleZ = transform.eulerAngles.z;
				transform.eulerAngles = new Vector3(0,0,-angleZ);
			} else if(transform.eulerAngles.z>90f && transform.eulerAngles.z<=200f){ // esquerda
				//Debug.Log("b:"+transform.eulerAngles.z);
				transform.eulerAngles = new Vector3(0,0,transform.eulerAngles.z-1f);
				//Debug.Log("a:"+transform.eulerAngles.z);
			} else if(transform.eulerAngles.z<270f && transform.eulerAngles.z>120f){ //direita
				transform.eulerAngles = new Vector3(0,0,transform.eulerAngles.z+1f);
			} else {
				Debug.Log("???: "+transform.eulerAngles);
			}
			radioController.ChangeFrequency(transform.eulerAngles.z);
			//Debug.Log("eu: "+transform.eulerAngles);
		}
	}

	
}
