using UnityEngine;
using System.Collections;

public class WallManager : MonoBehaviour {

	GameObject[,] WallGrid = new GameObject[10,10];
	Object WallBase;
	static float wSize = 5;
	static float wOffset = wSize/2;
	int layermask = 511;

	// Use this for initialization
	void Start () {

		WallBase = Resources.Load ("Prefabs/Wall");

		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 10; j++) {
				Vector3 pos = new Vector3(wSize * i + wOffset, 1, wSize * j + wOffset);
				WallGrid[i,j] = (GameObject) Instantiate(WallBase, pos, Quaternion.identity);
				WallGrid[i,j].name = "Wall(" + i + "," + j + ")";
			}
		}
	}

	static Vector3 WorldToGrid(Vector3 input) {
		Vector3 output = new Vector3();

		output.x = (int) (input.x - wOffset) / wSize;
		output.z = (int) (input.z - wOffset) / wSize;
		output.y = input.y;

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
		Vector3 wallHit;

		if (Input.GetButtonDown("Fire1")) {
			// Creates a ray from the camera through the cursor
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			// If the ray hits a wall, this destroys the wall
			if (Physics.Raycast (ray, out hit, 200, layermask) && hit.collider.name == "Wall") {
				wallHit = WorldToGrid (hit.point);
				Destroy (WallGrid[(int) wallHit.x, (int) wallHit.z], 0.2f);
				WallGrid[(int) wallHit.x, (int) wallHit.z] = null;
			}
		}
	}
}
