using UnityEngine;
using System.Collections;

public class videoController : MonoBehaviour {

    MovieTexture movie;
	// Use this for initialization
	void Start () {
        Renderer rend = this.GetComponent<Renderer>();
        rend.material.mainTexture = Resources.Load("Video/SplashScreen_1") as MovieTexture;
        movie = (MovieTexture)Resources.Load("Video/SplashScreen_1");
        movie.Play();
        movie.loop = true;

        //AudioSource sound = GetComponent<AudioSource>();
       // sound.sou = Resources.Load("Video/dungeonAmbiance1") as AudioSource;
        //sound.Play();
        //sound.loop = true;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
