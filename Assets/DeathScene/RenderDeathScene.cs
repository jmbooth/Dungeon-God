using UnityEngine;
using System.Collections;
using UnityEditor;

public class RenderDeathScene : MonoBehaviour {

    public Texture drawTextImage;
    float previousTime;
    float a;
    float fadeSpeed { get; set; } //How much the opacity increases by
    float fadeTime { get; set; }// Time that fade speed increments in millisecs
    bool isDead { get; set; }
    bool isInside = false;
    // Use this for initialization
    void Start () {
       previousTime = Time.time;
        fadeSpeed = 0.10f;
        a = 0;
        fadeTime = 20;
        isDead = false;
	}
   
    void drawDeath()
    {
        if (isDead)
        {
            if ((Time.time * 1000) - (previousTime * 1000) >= fadeTime)
            {
                previousTime = Time.time;
                if (a != 1)
                {
                    a += fadeSpeed;
                }
            }
            if (drawTextImage == null)
            {
                //drawTextImage = (Texture2D)Resources.Load(@"Assets/metal.png");
            }
            if (drawTextImage == null)
            {
                Debug.Log("It's not getting set");
                // return;
            }
            Color temp = GUI.color;
           /* if (isInside)
            {
                temp = Color.blue;
            }*/
            temp.a = a;
            GUI.color = temp;



            GUI.DrawTexture(new Rect(Camera.main.rect.x, Camera.main.rect.y, Screen.width, Screen.height), drawTextImage);
            temp.a = 1;
            GUI.color = temp;
        }
    }
 
    void OnGUI()
    {
        drawDeath();
    }

    // Update is called once per frame
    void Update () {
        Rect rect = new Rect(Camera.main.rect.x, Camera.main.rect.y, 150, 150);
       /* if (rect.Contains(Input.mousePosition))
        {
            isInside = true;
        }
        else
        {
            isInside = false;
        }*/
        
	}
}
