using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

	public TargetController selectedTarget;
	public int targetX;
	public int targetY;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SelectTarget(TargetController target){
		if(selectedTarget!=null){
			selectedTarget.Select(false);
		}
		if(selectedTarget==target){
			selectedTarget = null;
			return;
		}
		selectedTarget = target;
		if(target.x==targetX && target.y==targetY){
			Debug.Log("ponto certo!");
		} else {
			Debug.Log("ponto errado!");
		}
	}
}
