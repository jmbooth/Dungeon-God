using UnityEngine;
using System.Collections;

public class TrapFactory : MonoBehaviour {

	float location_temp;

	// Use this for initialization
	void Start () {
		location_temp = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Fire1"))
		{
			//Vector3 mousePos = Input.mousePosition;
			//mousePos.z = 2;
			//mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			Vector3 mousePos = new Vector3(location_temp, 2f, 0f);
			Object trap = Resources.Load("Prefabs/SpikePitPrefab 1");
			
			Instantiate(trap, mousePos, Quaternion.identity);

			location_temp += 2;
		}
	}
}
