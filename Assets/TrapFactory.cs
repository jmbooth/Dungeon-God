using UnityEngine;
using System.Collections;

public class TrapFactory : MonoBehaviour {

	Object trapBase;
	GameObject trapClone;
	float location_temp;

	// Use this for initialization
	void Start () {
		trapBase = Resources.Load ("Prefabs/SpikePitPrefab 1");
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
			if (Physics.Raycast (ray, out hit, 200) && hit.collider.name == "Terrain") {
				Debug.Log("I cast Ray and hit " + hit.collider.name);
				
				terrainHit = hit.point;
				trapClone = (GameObject) Instantiate(trapBase, terrainHit, Quaternion.identity);
			}
		}

		// Hold the left mouse button to drag the trap
		if (Input.GetButton ("Fire1"))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray, out hit, 200, 255) && hit.collider.name == "Terrain") {
				terrainHit = hit.point;
				trapClone.transform.Translate(hit.point - trapClone.transform.position);
			}
		}

		// Release the mouse button to set the trap
		if (Input.GetButtonUp ("Fire1")) {
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			if (Physics.Raycast (ray, out hit, 200) && hit.collider.name == "Terrain") {
				terrainHit = hit.point;
				trapClone.transform.Translate (hit.point);

				trapClone = null;
				Debug.Log ("Trap Placed");
			}
		}
	}
}
