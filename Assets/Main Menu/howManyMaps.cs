using UnityEngine;
using System.Collections;

public class howManyMaps : MonoBehaviour {

    GameObject[] buttons = new GameObject[6]; //buttons object holder
    GameObject[] mapImages = new GameObject[6]; //map image holder
    GameObject[] texts = new GameObject[6]; //label holder
    GameObject[] outline = new GameObject[6];//outline holder

    public int mapsNum = 3; //number of maps to be shown
    // Use this for initialization
    void Start () { //loads all the images and buttons
        buttons[0] = GameObject.Find("hiddenButton_1");
        buttons[1] = GameObject.Find("hiddenButton_2");
        buttons[2] = GameObject.Find("hiddenButton_3");
        buttons[3] = GameObject.Find("hiddenButton_4");
        buttons[4] = GameObject.Find("hiddenButton_5");
        buttons[5] = GameObject.Find("hiddenButton_6");
        mapImages[0] = GameObject.Find("Map_1");
        mapImages[1] = GameObject.Find("Map_2");
        mapImages[2] = GameObject.Find("Map_3");
        mapImages[3] = GameObject.Find("Map_4");
        mapImages[4] = GameObject.Find("Map_5");
        mapImages[5] = GameObject.Find("Map_6");
        texts[0] = GameObject.Find("mapLabel_1");
        texts[1] = GameObject.Find("mapLabel_2");
        texts[2] = GameObject.Find("mapLabel_3");
        texts[3] = GameObject.Find("mapLabel_4");
        texts[4] = GameObject.Find("mapLabel_5");
        texts[5] = GameObject.Find("mapLabel_6");
        outline[0] = GameObject.Find("outline_1");
        outline[1] = GameObject.Find("outline_2");
        outline[2] = GameObject.Find("outline_3");
        outline[3] = GameObject.Find("outline_4");
        outline[4] = GameObject.Find("outline_5");
        outline[5] = GameObject.Find("outline_6");
    }
    
    // Update is called once per frame
    void Update () {
        for (int count = mapsNum; count < 6; count++)
        {
            buttons[count].SetActive(false);
            mapImages[count].SetActive(false);
            texts[count].SetActive(false);
            outline[count].SetActive(false);
        }
	}
}
