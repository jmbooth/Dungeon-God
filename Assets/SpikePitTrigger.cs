
using UnityEngine;
using System.Collections;

public class SpikePitTrigger : MonoBehaviour {

	static float cooldown = 10; // in seconds
	static int damage = 10;
	float sinceLastTrigger; // in seconds

	// Use this for initialization
	void Start () {
		sinceLastTrigger = cooldown;
	}
	
	// Update is called once per frame
	void Update () {
		if (sinceLastTrigger <= cooldown) {
			sinceLastTrigger += Time.deltaTime;
		}
	}

    void OnTriggerEnter(Collider collider)
    {
		if (sinceLastTrigger >= cooldown) {
		Debug.Log ("Ahaha!");
			collider.gameObject.SendMessage ("TakeDamage", damage);
			sinceLastTrigger = 0;
		}

    }
}
