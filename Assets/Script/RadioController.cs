using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour {

	public GameObject display;
	public GameObject pointer;
	public GameObject tuneButton;
	public GameObject turnOnButton;
	public float startFrequency;
	public float frequency;

	void Start () {
		frequency = startFrequency;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
}
