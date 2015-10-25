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
    private bool[] mSelect = {false,false,false,false,false,false };
    private bool[] tSelect = { false, false, false, false, false, false };

    void Start () {
        Transform canvasTrans = Instantiate (uiPrefab, 
                                new Vector3 (145, 25, 0), Quaternion.identity) as Transform;
        buttonPanels[0] = GameObject.Find("TrapPanel");
        buttonPanels[1] = GameObject.Find("MonsterPanel");
        mButton = GameObject.Find("Monsters").GetComponent<Button>();
        tButton = GameObject.Find("Traps").GetComponent<Button>();
        tButton.onClick.AddListener(() => { SetActivePanel(0); });
        mButton.onClick.AddListener(() => { SetActivePanel(1); });
              string t = "TrapPanel";
              string m = "MonsterPanel";
              trapButtons = GameObject.Find(t).GetComponents<Button>();
              monsterButtons = GameObject.Find(m).GetComponents<Button>();
        buttonPanels[1].SetActive(false);
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
    }
	
	// Update is called once per frame
	void Update () {
        
        for(int i=0; i<monsterButtons.Length; i++)
        {
            if (mSelect[i] = true && Input.GetMouseButtonUp(3))
            {

            }
            else {
                // remove highlight
            }
            if (tSelect[i] = true && Input.GetMouseButtonUp(3))
            {

            }
            else {
                // remove highlight
            }
            }
        
    }

    void TrapHandler(int t)
    {
        for (int i = 0; i < monsterButtons.Length; i++)
        {
            if (i == t)
                tSelect[i] = true;
            else
                tSelect[i] = false;
        }
        while (1 == 1)
        {
            if (tSelect[t] == false || Input.GetMouseButtonDown(2))
                break;
        }
    }

    void MonsterHandler(int m)
    {
        for(int i = 0; i < monsterButtons.Length; i++)
        {
            if (i == m)
                mSelect[i] = true;
            else
                mSelect[i] = false;
        }
        while (1==1)
        {

            if (mSelect[m] == false||Input.GetMouseButtonDown(2))
                break;
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