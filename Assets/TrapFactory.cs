using UnityEngine;
using System.Collections;

public class TrapFactory : MonoBehaviour {

	Object trap;
	float location_temp;

	// Use this for initialization
	void Start () {
		trap = Resources.Load ("Prefabs/SpikePitPrefab 1");
	}
	
	// Update is called once per frame
	void Update () {

		// If the left mouse button is released
		if (Input.GetButtonUp ("Fire1"))
		{
			// Creates a ray from the camera through the cursor
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// If the ray hits the terrain, create a trap on the terrain.
			if (Physics.Raycast (ray, out hit, 200) && hit.collider.name == "Terrain") {
				Debug.Log("I cast Ray and hit " + hit.collider.name);
			
				Vector3 terrainHit = hit.point;
				Instantiate(trap, terrainHit, Quaternion.identity);
			}
		}
	}
}
