using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioHandlerController : MonoBehaviour {

	public TuneButtonController tune;
	public bool turning = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(turning){
			//Debug.Log(transform.position);
			tune.Rotate(transform.position);
		}
	}

	void OnMouseDown(){
		if(!RadioController.instance.messageStation.messagePlaying || 
		(RadioController.instance.messageStation.messagePlaying && RadioController.instance.messageStation != RadioController.instance.currentStation) ){
			turning = true;
		}
	}

	void OnMouseUp(){
		turning = false;
	}

	void OnMouseExit(){
		turning = false;
	}
}
