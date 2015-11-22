using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class uiButtonHandler : MonoBehaviour {
	protected bool toggleFlag = false;
	protected GameObject[] buttonPanels = new GameObject[2];
	// Use this for initialization
	void Start () {

		buttonPanels[0] = GameObject.Find("TrapPanel");
		buttonPanels[1] = GameObject.Find("MonsterPanel");	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void monsterHandler(String b){
		Debug.Log ("here");
		Debug.Log(b+" got clicked");
	}

	public void trapHandler(String b){
		Debug.Log ("here");
		Debug.Log(b + " got clicked");
	}

	public void SetActivePanel(string b)
	{

		Debug.Log ("toggle button pressed");
		if (toggleFlag)
		{
			GameObject.Find(b).GetComponentInChildren<Text>().text= "Traps";
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
