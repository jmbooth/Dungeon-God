using UnityEngine;
using System.Collections;

public class TopDownCameraController : MonoBehaviour {

	public float scrollSpeed = .1f;

	public float maxX = 20;
	public float minX = 0;
	public float maxZ = 20;
	public float minZ = 0;

	// Use this for initialization
	void Start () 
	{
	
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.W) && this.transform.position.x < maxX) {
			this.transform.position =  new Vector3(this.transform.position.x+scrollSpeed, this.transform.position.y, this.transform.position.z);
		}
		if(Input.GetKey (KeyCode.A) && this.transform.position.z < maxZ) {	
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z+ scrollSpeed);
		}
		if (Input.GetKey (KeyCode.S) && this.transform.position.x > minX) {
			this.transform.position = new Vector3(this.transform.position.x- scrollSpeed, this.transform.position.y, this.transform.position.z);
		}
		if(Input.GetKey (KeyCode.D) && this.transform.position.z > minZ) {	
			this.transform.position =  new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z- scrollSpeed);
		}
	}
}
