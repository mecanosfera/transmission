using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuneButtonController : MonoBehaviour {

	public RadioController radioController;
	bool turning = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(turning){
			Debug.Log(radioController.frequency);
		}
	}

	void OnMouseDown(){
		turning = true;
	}

	void OnMouseUp(){
		turning = false;
	}

	void OnMouseExit(){
		turning = false;
	}
}
