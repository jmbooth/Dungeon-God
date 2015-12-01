using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class uiButtonHandler : MonoBehaviour {
	protected bool toggleFlag = false;
	protected GameObject[] buttonPanels = new GameObject[2];
	protected bool[] inUse = new bool[12];
	protected TrapFactory factoryScript; 
	protected int[] tCost = new int[6];
	protected int[] mCost = new int[6];
	uiHandler uiScript;
	GameObject tFactory;
	public GameObject theCanvas;
	// Use this for initialization
	void Start () {
		factoryScript = GetComponent<TrapFactory> ();
		buttonPanels[0] = GameObject.Find("TrapPanel");
		buttonPanels[1] = GameObject.Find("MonsterPanel");	
		//hide monster panel
		buttonPanels[1].SetActive(false);
		for (int i=0; i<12; i++)
			inUse [i] = false;
		uiScript = GameObject.Find ("UICanvas").GetComponent <uiHandler>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void monsterHandler(String b){

	}

	public void trapHandler(String b){
		char c = b [b.Length - 1];
		Debug.Log (uiScript.playerGold);
		if (uiScript.playerGold > tCost [c - '0'] && !inUse [(c - '0') - 1]) {
			//trap placement active
			inUse [c - '0'] = true;
			tFactory.SetActive(true);
		} else if (inUse [(c - '0') - 1]) {
			//trap placement inactive
			inUse[(c-'0')-1]=false;
		}else
			Debug.Log ("not enough gold");
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