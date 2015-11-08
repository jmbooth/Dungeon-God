﻿using UnityEngine;
using System.Collections;

public class WallManager : MonoBehaviour {

	static int gridDim = 20;
	GameObject[,] WallGrid = new GameObject[gridDim,gridDim];
	Object WallBase;
	Object TrapBase;
	static int wSize = 2; // Grid square size
	static float wOffset = wSize / 2.0f;
	int layermask = 256;

	// Use this for initialization
	void Start () {

		WallBase = Resources.Load ("Prefabs/Wall");
		TrapBase = Resources.Load ("Prefabs/SpikePitPrefab 1");

		/*for (int i = 0; i < gridDim; i++) {
			for (int j = 0; j < gridDim; j++) {
				Vector3 pos = new Vector3(wSize * i + wOffset, 1, wSize * j + wOffset);
				WallGrid[i,j] = (GameObject) Instantiate(WallBase, pos, Quaternion.identity);
				WallGrid[i,j].name = "Wall(" + i + "," + j + ")";
			}
		}*/
	}

	static int[] WorldToGrid(Vector3 input) {
		int[] output = new int[2];

		//output[0] = (int) Mathf.Floor ((input.x - wOffset) / wSize);
		//output[1] = (int) Mathf.Floor ((input.z - wOffset) / wSize);

		output [0] = (Mathf.FloorToInt(input.x)) / wSize;
		output [1] = (Mathf.FloorToInt(input.z)) / wSize;

		return output;
	}

	static Vector3 GridToWorld(Vector3 input) {
		Vector3 output = new Vector3 ();

		output.x = (input.x * wSize) + wOffset;
		output.z = (input.z * wSize) + wOffset;
		output.y = input.y;

		return output;
	}

	public GameObject[,] getList()
	{
		return WallGrid;
	}

	// Update is called once per frame
	void Update () {
		Ray ray;
		RaycastHit hit;

		if (Input.GetButtonDown ("Fire1")) {
			// Creates a ray from the camera through the cursor
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			// If the ray hits a wall, this destroys the wall
			if (Physics.Raycast (ray, out hit, 200, layermask)) {
				int[] wallHit = WorldToGrid (hit.point);

				Debug.Log ("Coords x: " + hit.point.x + "  z: " + hit.point.z);
				Debug.Log ("Grid place x: " + wallHit [0] + "  z: " + wallHit [1]);

				//if the wall already exists then destroy it
				if(WallGrid[wallHit [0],wallHit [1]] != null)
				{
					Destroy (WallGrid [wallHit [0], wallHit [1]], 0.2f);
					WallGrid [wallHit [0], wallHit [1]] = null;
				}else
				{
					//create new wall instead of destroy it
					Vector3 pos = new Vector3 ((wallHit[0] * wSize) + wOffset, 0.5f, (wallHit[1] * wSize) + wOffset);
					WallGrid[wallHit [0],wallHit [1]] = (GameObject)Instantiate (WallBase, pos, Quaternion.identity);
					WallGrid[wallHit [0],wallHit [1]].name = "Wall(" + wallHit[0] + "," + wallHit[1] + ")";
				}

			}

		} else if (Input.GetButtonDown ("Fire2")) {

			ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit, 200, 2048)) {
				int[] floorHit = WorldToGrid (hit.point);

				//if there is already something there - don't place a trap under it
				if(WallGrid[floorHit [0],floorHit [1]] == null)
				{
					Debug.Log ("Coords x: " + hit.point.x + "  z: " + hit.point.z);
					Debug.Log ("Grid place x: " + floorHit [0] + "  z: " + floorHit [1]);

					Vector3 pos = new Vector3 ((floorHit[0] * wSize) + wOffset, 0.5f, (floorHit[1] * wSize) + wOffset);
					WallGrid[floorHit [0],floorHit [1]] = (GameObject)Instantiate (TrapBase, pos, Quaternion.identity);
				}
			}
		}
	}
}