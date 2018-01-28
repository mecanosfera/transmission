using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MorseReceiverController : MonoBehaviour {

	public GameObject message;
	public Text messageText;
	public GameObject morseSenderButton;
	public float sendTimer = 5f;
	public bool sending = false;
	public float receiveTimer = 5f;
	public bool receiving = false;
	public string sendMsg;
	public float clearTimer = 5f;
	bool cleaning = false;
	public Sprite notepadMsg;
	public GameObject notepad;
	public SpriteRenderer notepadR;
	bool sendNotepad = false;
	float sendPos = 0.25f;
	Vector3 sendStartPos;
	float animTimer = 0f;
	float messageStart;

	void Start () {
		notepadR = notepad.GetComponent<SpriteRenderer>();
		messageStart = message.transform.position.x;
		sendStartPos = morseSenderButton.transform.position;
		ReceiveMessage("Agente, nossos espiões descobriram que uma mensagem oculta será transmitida às 16:30 hrs em pleno programa de músicas na rádio local, frequência 102.6 MHz", true);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(receiving){
			//Debug.Log("receive":+receiveTimer);
			receiveTimer -= Time.deltaTime;
			message.transform.position -= new Vector3(Time.deltaTime*1.4f,0,0);
			if(receiveTimer<=0f){
				receiving = false;
				receiveTimer = 5f;
				cleaning = true;
				if(sendNotepad){
					notepadR.sprite = notepadMsg;
					sendNotepad = false;
				}
			}
		}
		if(sending){
			sendTimer -= Time.deltaTime;
			animTimer += Time.deltaTime;
			if(animTimer>0.5f){
				sendPos *= -1;
				morseSenderButton.transform.position += new Vector3(sendPos,0,0);
				animTimer = 0f;
			}
			
			if(sendTimer<=0f){
				sending = false;
				sendTimer = 5f;
				morseSenderButton.transform.position = sendStartPos;
				sendPos = 0.25f;
				animTimer = 0f;
				ReceiveMessage(sendMsg);
			}
		}
		if(cleaning){
			clearTimer -= Time.deltaTime;
			if(clearTimer<=0f){
				cleaning = false;
				clearTimer = 5f;
				message.transform.position = new Vector3(messageStart,message.transform.position.y,message.transform.position.z);
			}
		}
	}

	public void SendMsg(string msg){
		sending = true;
		sendMsg = msg;
	}

	public void ReceiveMessage(string msg, bool note=false){
		cleaning = false;
		message.transform.position = new Vector3(messageStart,message.transform.position.y,message.transform.position.z);
		messageText.text = msg;
		sendNotepad = note;
		receiving = true;
	}
}
