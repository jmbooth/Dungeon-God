using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public void SwitchScene(int level)
    {
        Application.LoadLevel(level);
    }
    public void loadMap(int mapNum)
    {
        Application.LoadLevel(mapNum + 3);
    }
    // Update is called once per frame
    void Update () {
	
	}
}
