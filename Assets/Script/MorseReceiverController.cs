using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MorseReceiverController : MonoBehaviour {

	public GameObject message;
	public Text messageText;
	public GameObject morseSender;
	public SpriteRenderer morseSenderRenderer;
	public float sendTimer = 5f;
	public bool sending = false;
	public float receiveTimer = 8f;
	public bool receiving = false;
	public string sendMsg;
	public float clearTimer = 5f;
	bool cleaning = false;

	void Start () {
		morseSenderRenderer = morseSender.GetComponent<SpriteRenderer>();
		ReceiveMessage("Escute a rádio de música às 4:30 pm");
	}
	
	// Update is called once per frame
	void Update () {
		if(receiving){
			receiveTimer -= Time.deltaTime;
			message.transform.position -= new Vector3(Time.deltaTime,0,0);
			if(receiveTimer<=0f){
				receiving = false;
				receiveTimer = 5f;
				cleaning = true;
			}
		}
		if(sending){
			sendTimer -= Time.deltaTime;
			if(sendTimer<=0f){
				sending = false;
				sendTimer = 5f;
				ReceiveMessage(sendMsg);
			}
		}
		if(cleaning){
			clearTimer -= Time.deltaTime;
			if(clearTimer<=0f){
				cleaning = false;
				clearTimer = 8f;
				message.transform.position += new Vector3(10f,0,0);
			}
		}
	}

	public void SendMsg(string msg){
		sending = true;
		sendMsg = msg;
	}

	public void ReceiveMessage(string msg){
		messageText.text = msg;
		receiving = true;
	}
}
