using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/*
Prefab layout
UI Canvas-->uiPanel  -->trapPanel   --> 6 Buttons -->Text Component
						buttonPanel --> 6 Buttons -->Text Component
						trapButton
						monsterButton
*/

public class uiHandler : MonoBehaviour {
	// Use this for initialization
	protected Button[] trapButtons = new Button[6];
	protected Button[] monsterButtons = new Button[6];
	protected GameObject[] buttonPanels = new GameObject[2];
	protected Button tButton;
	public Transform uiPrefab;
	private Transform monsterPrefabs;
	private Transform trapPrefabs;
	private bool[] mSelect = { false, false, false, false, false, false };
	private bool[] tSelect = { false, false, false, false, false, false };
	protected bool toggleFlag=true;
	protected int playerGold;
	protected Text goldText;
	void Start () {
		
		//Transform canvasTrans = Instantiate (uiPrefab, 
		//						new Vector3 (145, 25, 0), Quaternion.identity) as Transform;
		// panels that contain the buttons
		buttonPanels[0] = GameObject.Find("TrapPanel");
		buttonPanels[1] = GameObject.Find("MonsterPanel");
		goldText = GameObject.Find("GoldText").GetComponent<Text>();
		playerGold = 10;
		// these buttons switch between the main button panels
		tButton = GameObject.Find("ToggleButton").GetComponent<Button>();
		//init rest of the buttons
		trapButtons = buttonPanels[0].GetComponentsInChildren<Button>();
		monsterButtons = buttonPanels[1].GetComponentsInChildren<Button>();
		// set listeners

		//hide monster panel
		buttonPanels[1].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//update Player gold text
		goldText.text = "Gold: "+playerGold;
	}

	void setPlayerGold(int gold){
		playerGold = gold;
	}

	int getPlayerGold(){
		return playerGold;
	}
}