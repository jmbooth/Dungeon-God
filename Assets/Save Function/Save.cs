using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

//from http://gamedevelopment.tutsplus.com/tutorials/how-to-save-and-load-your-players-progress-in-unity--cms-20934
//reference: http://docs.unity3d.com/Manual/script-Serialization.html
public class Save : MonoBehaviour
{
    public static List<string> savedGames = new List<string>();
    public int fileNo;
    public bool showGUI = false;
    public string stringToEdit = "Autosave";
    int boxcount = 0;
    //it's static so we can call it from anywhere
    public  void save2()
    {
        EditorApplication.Beep();
        showGUI = true;
        Debug.Log("showguid is " + stringToEdit);
        fileNo++;
          Save.savedGames.Add(Application.persistentDataPath + " " + stringToEdit);
           BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames" + stringToEdit + ".gd" ) ; 
            Debug.Log("saved " + Application.persistentDataPath + "/savedGames" + stringToEdit + ".gd");
        bf.Serialize(file, Save.savedGames);
           file.Close();
        boxcount++;
        if(boxcount % 2 == 0)
        {
            showGUI = false;
        }
    }

    public void load2()
    {
        showGUI = true;
        boxcount++;
        Debug.Log("File we are looking for is " + Application.persistentDataPath + "/savedGames" + stringToEdit+".gd");
        if (File.Exists(Application.persistentDataPath + "/savedGames" + stringToEdit+".gd"))
        {
            Debug.Log("Found the file");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames" + stringToEdit+".gd", FileMode.Open);
            Save.savedGames = (List<string>)bf.Deserialize(file);
            file.Close();
            Debug.Log("Closed the file");
        }
        else
        {
            Debug.Log("couldn't find file");
        }
        if (boxcount % 2 == 0)
        {
            showGUI = false;
        }
    }


    //from http://docs.unity3d.com/ScriptReference/GUI.TextField.html
    public void OnGUI()
    {
        if (!showGUI) { return; }
        stringToEdit = GUI.TextField(new Rect(10, 10, 200, 20), stringToEdit, 25);
    }
}
