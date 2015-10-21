using UnityEngine;
using System.Collections;

public class WallManager : MonoBehaviour {

	GameObject[,] WallGrid = new GameObject[10,10];
	Object WallBase;
	Object TrapBase;
	static int wSize = 5;
	static float wOffset = wSize / 2.0f;
	int layermask = 256;

	// Use this for initialization
	void Start () {

		WallBase = Resources.Load ("Prefabs/Wall");
		TrapBase = Resources.Load ("Prefabs/SpikePitPrefab 1");

		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 10; j++) {
				Vector3 pos = new Vector3(wSize * i + wOffset, 1, wSize * j + wOffset);
				WallGrid[i,j] = (GameObject) Instantiate(WallBase, pos, Quaternion.identity);
				WallGrid[i,j].name = "Wall(" + i + "," + j + ")";
			}
		}
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

				Destroy (WallGrid [wallHit [0], wallHit [1]], 0.2f);
				WallGrid [wallHit [0], wallHit [1]] = null;
			}

		} else if (Input.GetButtonDown ("Fire2")) {

			ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit, 200, 2048)) {
				int[] floorHit = WorldToGrid (hit.point);

				Debug.Log ("Coords x: " + hit.point.x + "  z: " + hit.point.z);
				Debug.Log ("Grid place x: " + floorHit [0] + "  z: " + floorHit [1]);

				Vector3 pos = new Vector3 ((floorHit[0] * wSize) + wOffset, 0.5f, (floorHit[1] * wSize) + wOffset);
				Instantiate (TrapBase, pos, Quaternion.identity);
			}
		}
	}
}
