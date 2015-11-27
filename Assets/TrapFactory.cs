using UnityEngine;
using System.Collections;

public class TrapFactory : MonoBehaviour {

	Object trapBase;
	Object trapGhost;
	GameObject trapClone;

	float location_temp;
	int layermask;
	float vOffset = 0.2f;

	// Use this for initialization
	void Start () {
		trapBase = Resources.Load ("Prefabs/SpikePitPrefab 1");
		trapGhost = Resources.Load ("Prefabs/SpikePitGhost");
		layermask = 1023;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray;
		RaycastHit hit;
		Vector3 terrainHit;

		// Press the left mouse button to instantiate a trap
		if (Input.GetButtonDown ("Fire1")) {
			// Creates a ray from the camera through the cursor
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// If the ray hits the terrain, create a trap on the terrain.
			if (Physics.Raycast (ray, out hit, 200, layermask) && hit.collider.name == "Terrain") {
				terrainHit = hit.point;
				terrainHit.y += vOffset;
				trapClone = (GameObject) Instantiate(trapGhost, hit.point, Quaternion.identity);
			}
		}

		// Hold the left mouse button to drag the trap
		if (Input.GetButton ("Fire1"))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray, out hit, 200, layermask) && hit.collider.name == "Terrain") {
				terrainHit = hit.point;
				terrainHit.y += vOffset;
				trapClone.transform.Translate(terrainHit - trapClone.transform.position);
			}
		}

		// Release the mouse button to set the trap
		if (Input.GetButtonUp ("Fire1")) {
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			if (Physics.Raycast (ray, out hit, 200, layermask) && hit.collider.name == "Terrain") {
				
				terrainHit = hit.point;
				terrainHit.y += vOffset;

				trapClone.transform.Translate (terrainHit - trapClone.transform.position);
				Object.Destroy(trapClone, 0.5f);
				trapClone = null;

				Instantiate(trapBase, terrainHit, Quaternion.identity);


				Debug.Log ("Trap Placed");
			}
		}
	}
}
