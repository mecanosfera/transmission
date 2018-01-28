using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

	public TargetController selectedTarget;
	public int targetX;
	public int targetY;
	public MorseReceiverController morse;
	BoxCollider2D box;
	void Start () {
		box = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SelectTarget(TargetController target){
		if(selectedTarget==target){
			selectedTarget = null;
			return;
		}
		selectedTarget = target;
		if(target.x==targetX && target.y==targetY){
			morse.SendMsg("Acertou!");
		} else {
			morse.SendMsg("Todo mundo morreu por culpa sua...");
		}
	}

}
