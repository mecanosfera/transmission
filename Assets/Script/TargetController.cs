using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

	public MapController map;
	public int x;
	public int y;
	public bool selected = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Select(bool sel){
		if(sel){
			selected = true;
			//mudar sprite
			map.SelectTarget(this);
		} else {
			selected = false;
			//mudar sprite
		}
	}

	void OnMouseDown(){
		Select(!selected);
	}


}
