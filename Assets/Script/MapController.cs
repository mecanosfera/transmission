using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour {

	public TargetController selectedTarget;
	public int targetX;
	public int targetY;
	public bool secondMsg = false;
	public MorseReceiverController morse;
	public Text coords;

	void Start () {
		coords.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if(selectedTarget==null && !secondMsg){
			if(ClockController.instance.hour==5 && ClockController.instance.minute>=30){
				morse.ReceiveMessage("Agente, ainda não recemos nenhuma informação. Precisamos da localização com urgência!");
				secondMsg = true;
			}
		}
	}

	public void SelectTarget(TargetController target){
		if(selectedTarget==target){
			selectedTarget = null;
			return;
		}
		selectedTarget = target;
		if(target.x==targetX && target.y==targetY){
			morse.SendMsg("Acreditamos que esse seja a possível localização de uma célula terrorista. Bom trabalho. Aguarde novas instruções.");
		} else {
			morse.SendMsg("Os agentes enviados a campo não encontraram nada no local informado. Uma nova falha não será tolerada. Fique atento, agente. Você está dispensado por hoje.");
		}
	}

}
