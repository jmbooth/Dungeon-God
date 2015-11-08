using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class uiButtonHandler : MonoBehaviour {
	protected bool toggleFlag = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void monsterHandler(string b){
		Debug.Log ("here");
		Debug.Log(b+" got clicked");
	}

	public void trapHandler(string b){
		Debug.Log ("here");
		Debug.Log(b + " got clicked");
	}

	void SetActivePanel(string b)
	{
		GameObject[] buttonPanels = new GameObject[2];
		buttonPanels[0] = GameObject.Find("TrapPanel");
		buttonPanels[1] = GameObject.Find("MonsterPanel");
		Debug.Log ("toggle button pressed");
		if (!toggleFlag)
		{
			GameObject.Find(b).GetComponentInChildren<Text>().text= "Trap";
			buttonPanels[1].SetActive(false);
			buttonPanels[0].SetActive(true);
		}
		else 
		{
			GameObject.Find(b).GetComponentInChildren<Text>().text= "Monsters";
			buttonPanels[0].SetActive(false);
			buttonPanels[1].SetActive(true);
		}
		toggleFlag = !toggleFlag;
	}

}
