using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIhandler : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnClicked(Button button){
		
		//place prefab script
		print(button.name);
	}
}
