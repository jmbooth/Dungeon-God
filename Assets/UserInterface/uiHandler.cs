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
    private Button[] trapButtons = new Button[6];
    private Button[] monsterButtons = new Button[6];
    private GameObject[] buttonPanels = new GameObject[2];
    private Button tButton;
    private Button mButton;
    public Transform uiPrefab;
    private Transform monsterPrefabs;
    private Transform trapPrefabs;
    private bool[] mSelect = { false, false, false, false, false, false };
    private bool[] tSelect = { false, false, false, false, false, false };

    void Start () {
        
        Transform canvasTrans = Instantiate (uiPrefab, 
                                new Vector3 (145, 25, 0), Quaternion.identity) as Transform;
        // panels that contain the buttons
        buttonPanels[0] = GameObject.Find("TrapPanel");
        buttonPanels[1] = GameObject.Find("MonsterPanel");
        // these buttons switch between the main button panels
        mButton = GameObject.Find("Monsters").GetComponent<Button>();
        tButton = GameObject.Find("Traps").GetComponent<Button>();
        tButton.onClick.AddListener(() => { SetActivePanel(0); });
        mButton.onClick.AddListener(() => { SetActivePanel(1); });
        //init rest of the buttons
        trapButtons = GameObject.Find("TrapPanel").GetComponents<Button>();
        monsterButtons = GameObject.Find("MonsterPanel").GetComponents<Button>();
        // set listeners
        for (int i = 0; i < trapButtons.Length; i++)
        {
            trapButtons[i].onClick.AddListener(() =>
            {
                TrapHandler(i);
            });
            monsterButtons[i].onClick.AddListener(() =>
            {
                MonsterHandler(i);
            });
        }
        //hide monster panel
        buttonPanels[1].SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        for(int i=0; i<monsterButtons.Length; i++)
        {
            /*
            if (mSelect[i] == true)
            {

            }
            else if () {
                mSelect[i] = false;
            }
            if (tSelect[i] == true)
            {
               
            }
            else if (){
                tSelect[i] = false;
            }
            */
         }
    }

    void TrapHandler(int t)
    {
        for (int i = 0; i < monsterButtons.Length; i++)
        {
            if (i == t && tSelect[i] == false)
            {
                tSelect[i] = true;
            }
            else
            {
                tSelect[i] = false;
            }
        }
    }

    void MonsterHandler(int m)
    {
        for(int i = 0; i < monsterButtons.Length; i++)
        {
            if (i == m & mSelect[i] == false)
            {
                mSelect[i] = true;
            }
            else
            {
                mSelect[i] = false;
            }
        }
    }

    void SetActivePanel(int p)
    {
        if (p == 0)
        {
            buttonPanels[1].SetActive(false);
            buttonPanels[0].SetActive(true);
        }
        else if (p == 1)
        {
            buttonPanels[0].SetActive(false);
            buttonPanels[1].SetActive(true);
        }
    }
}