using UnityEngine;
using System.Collections;

public class DummyAI : MonoBehaviour {

	float turnTime;

	// Use this for initialization
	void Start () {
		turnTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		turnTime += Time.deltaTime;
		if (turnTime < 4) {
			transform.Translate (Vector3.forward * 0.01f); 
		} else if (turnTime >= 4 && turnTime < 8) {
			transform.Translate (Vector3.back * 0.01f); 
		} else {
			turnTime = 0;
		}
	}

    void TakeDamage(int damage)
    {
        Debug.Log("Ow!, I took " + damage + " damage!");
    }
}
