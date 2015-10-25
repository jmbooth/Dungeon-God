using UnityEngine;
using System.Collections;

public class clickAction : MonoBehaviour {

    public GameObject Trap;
    public bool move;

	// Use this for initialization

	void Start () {
        move = false;
	}
	/*
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("mouse x")<0){

        }
	}
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(scanPos);
        offset = scanPos - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
       // Instantiate(Trap, new Vector3(0, 0, 0), Quaternion.identity);
        move = true;
     //Destroy(this.gameObject);
    }

//attach this script to a box temporarily and when done attach it to the button that Mica is working on.
    void OnMouseDrag(){
        //distanceToScreen is how far from the camera the mouse is
        //it is on the z axis
        float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        //posMove is a vector that moves the trap
        Vector3 posMove = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, distanceToScreen));

        //this line changes the position of the vector
        transform.position = new Vector3(posMove.x, transform.position.y, posMove.z);
    }
    */
}
