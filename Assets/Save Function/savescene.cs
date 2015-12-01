using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

//Handles saving/loading a scene, must be attatched to an empty game object
//to be seen by a button.  The lighting gets messed up sometimes when switching around
//scenes.  Make sure to disable lightmaps (continuous baking)
public class savescene: MonoBehaviour{
    public bool showGUI = false;
    public bool showLoadGUI = false;
    public string stringToEdit = "Autosave";//Name of file user gives
    int boxcount = 0;
    int loadCount = 0;


    //saves the scene, increments a counter. Click the save button once to bring up a textbox to enter the saved files desired
    //name.  Click save again to store the file with the given name.
    public void saveTheScene()
    {
     
        EditorApplication.Beep();//Important
       
        boxcount++;
        if (boxcount % 2 == 0)
        {
            showGUI = false;
            EditorApplication.SaveScene(Application.persistentDataPath + "/savedGames " + stringToEdit + ".gd");
            
        }
        else
        {
            showGUI = true;
        }
    }

    //loads a scene.  Click load once to bring up a textbox to enter a file name.  Click it again to attempt to load the given file
    public void loadTheScene()
    {
        EditorApplication.Beep();//Important
        showLoadGUI = false;
        loadCount++;
        if (loadCount % 2 == 0)
        {
            if (File.Exists(Application.persistentDataPath + "/savedGames " + stringToEdit + ".gd"))
            {
                showLoadGUI = false;
                EditorApplication.LoadLevelInPlayMode(Application.persistentDataPath + "/savedGames " + stringToEdit + ".gd");
            }
            else
            {
                Debug.Log("File does not exist");
            }
        }
        else
        {
            string[] listOfSavedGames = Directory.GetFiles(Application.persistentDataPath);
            foreach (string filename in listOfSavedGames)
            {
                Debug.Log("the file is " + filename);
            }
            showLoadGUI = true;
        }
        
    }

    public void OnGUI()
    {

        if (!showGUI) { }
        else
        {
            stringToEdit = GUI.TextField(new Rect(10, 10, 200, 20), stringToEdit, 25);
        }

        if (!showLoadGUI) { }
        else
        {
            stringToEdit = GUI.TextField(new Rect(10, 10, 200, 20), stringToEdit, 25);
        }
    }

}
