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
	public bool on = true;

	void Start () {
		frequency = startFrequency;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeFrequency(float angle){
		if(angle<=90f || angle>=270f){
			pointer.transform.localRotation = Quaternion.Euler(0f, 0f, angle);
		}
		Debug.Log(angle);
	}

	
}
