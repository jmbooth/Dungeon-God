using UnityEngine;
using System.Collections;

public class TopDownCameraController : MonoBehaviour {

	public float scrollSpeed = .1f;

	// Use this for initialization
	void Start () 
	{
	
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.W)) {
			this.transform.position =  new Vector3(this.transform.position.x+scrollSpeed, this.transform.position.y, this.transform.position.z);
		}else if(Input.GetKey (KeyCode.A)) {	
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z+ scrollSpeed);
		}else if (Input.GetKey (KeyCode.S)) {
			this.transform.position = new Vector3(this.transform.position.x- scrollSpeed, this.transform.position.y, this.transform.position.z);
		}else if(Input.GetKey (KeyCode.D)) {	
			this.transform.position =  new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z- scrollSpeed);
		}
	}
}
