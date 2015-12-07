using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;


public class uiButtonHandler : MonoBehaviour
{
	protected bool toggleFlag = false;

	protected GameObject[] buttonPanels = new GameObject[2];
	protected bool[] inUse = new bool[12];
	protected TrapFactory factoryScript;
	protected int[] tCost = new int[6];
	protected int[] mCost = new int[6];
	uiHandler uiScript;
	//GameObject tFactory;
	public GameObject theCanvas;
	// Use this for initialization

	//This is stuff that should probably be in another class, but I'm putting here because deadline -Rex ---
	UnityEngine.Object trapBase;
	UnityEngine.Object trapGhost;
	GameObject trapClone;

	public WallManager walls;
	
	float location_temp;
	static int layermask = 2047;
	static float vOffset = 0.2f;
	static int wSize = 5;
	static float wOffset = wSize / 2.0f;

	Mode mMode;
	//End my section ---------

	void Start ()
	{
		factoryScript = GetComponent<TrapFactory> ();
		buttonPanels [0] = GameObject.Find ("TrapPanel");
		buttonPanels [1] = GameObject.Find ("MonsterPanel");	
		//hide monster panel
		buttonPanels [1].SetActive (false);
		for (int i=0; i<12; i++)
			inUse [i] = false;
		tCost [0] = 1;
		uiScript = GameObject.Find ("UICanvas").GetComponent <uiHandler> ();
		//Rex stuff
		trapBase = Resources.Load ("Prefabs/SpikePitPrefab 1");
		trapGhost = Resources.Load ("Prefabs/SpikePitGhost");

		mMode = Mode.OPEN;
	}
	
	//NOTE: THIS SHOULD ALL GO SOMEWHERE ELse --Rex
	void Update ()
	{
		
		Ray ray;
		RaycastHit hit;
		Vector3 terrainHit;
		
		if (mMode == Mode.OBJECT ) {
			// Hold the left mouse button to drag the trap
			//if (Input.GetButton ("Fire1")) {
			Debug.Log ("Shit happens more");
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				
			if (Physics.Raycast (ray, out hit, 200, layermask) ){ //&& hit.collider.name == "Terrain") {
				terrainHit = hit.point;
				terrainHit.y += vOffset;

				Debug.Log ("$$1 Terrain: x " + terrainHit.x + "  y " + terrainHit.y); 
				terrainHit.y = 1;
				Debug.Log ("$$2 Terrain: x " + terrainHit.x + "  y " + terrainHit.y); 

				trapClone.transform.Translate (terrainHit - trapClone.transform.position);

				if (Input.GetButtonDown ("Fire1")) {
					
					UnityEngine.Object.Destroy (trapClone, 0.1f);
					trapClone = null;

					int x = (int) WorldToGrid(terrainHit).x;
					int z = (int) WorldToGrid (terrainHit).z;

					Vector3 pos = new Vector3((x * wSize) + wOffset, 0.5f, (z * wSize) + wOffset);

					walls.SetList(x, z, (GameObject) Instantiate (trapBase, pos, Quaternion.identity), false);
					
					mMode = Mode.OPEN;
					Debug.Log ("Trap Placed");
				}
			}
		}
	}

	public void monsterHandler (String b)
	{
		Debug.Log ("here######");
		Debug.Log (b + " got clicked######");

		AttachObject (); 
	}

	public void trapHandler (String b)
	{
		char c = b [b.Length - 1];
		if (!inUse [(c - '0') - 1]) {
			//trap placement active
			inUse [c - '0'] = true;
		} else if (inUse [(c - '0') - 1]) {
			//trap placement inactive
			inUse [(c - '0') - 1] = false;
		} 
	}

	public void SetActivePanel (string b)
	{
		Debug.Log ("toggle button pressed");
		if (toggleFlag) {
			GameObject.Find (b).GetComponentInChildren<Text> ().text = "Traps";
			buttonPanels [1].SetActive (false);
			buttonPanels [0].SetActive (true);
		} else {
			GameObject.Find (b).GetComponentInChildren<Text> ().text = "Monsters";
			buttonPanels [0].SetActive (false);
			buttonPanels [1].SetActive (true);
		}
		toggleFlag = !toggleFlag;
	}
	
	/*Stolen and modified from the Wallmanager. A temporary fix. -R*/
	static Vector3 WorldToGrid (Vector3 input)
	{
		Vector3 output = new Vector3 (0, 0, 0);
		
		output.x = (Mathf.FloorToInt (input.x)) / wSize;
		output.y = input.y;
		output.z = (Mathf.FloorToInt (input.z)) / wSize;
		
		return output;
	}

	/*This should go somewhere else. And should take a parameter*/
	void AttachObject ()
	{
		Ray ray;
		RaycastHit hit;
		Vector3 terrainHit;

		// Creates a ray from the camera through the cursor
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		// If the ray hits the terrain, create a trap on the terrain.
		if (Physics.Raycast (ray, out hit, 200, layermask) && hit.collider.name == "Terrain") {
			terrainHit = hit.point;
			terrainHit.y += vOffset;
			terrainHit = WorldToGrid (terrainHit);
		} else {
			terrainHit = new Vector3 (0, 2, 0);
		}

		trapClone = (GameObject) Instantiate(trapGhost, terrainHit, Quaternion.identity);
		
		mMode = Mode.OBJECT;
	}
}
