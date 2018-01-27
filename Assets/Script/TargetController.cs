using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

	public MapController map;
	public int x;
	public int y;
	public bool selected = false;
	public Sprite selectedTarget;
	public Sprite notSelectedTarget;
	SpriteRenderer spriteR;

	void Start () {
		spriteR = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Select(bool sel){
		
			if(sel){
				selected = true;
				spriteR.sprite = selectedTarget;
				map.SelectTarget(this);
			} else {
				selected = false;
				spriteR.sprite = notSelectedTarget;
			}
		
	}

	void OnMouseDown(){
		if(map.selectedTarget!=this){
			Select(!selected);
		}
	}


}
