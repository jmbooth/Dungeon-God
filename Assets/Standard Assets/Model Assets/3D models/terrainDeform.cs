using UnityEngine;
using System.Collections;

public class terrainDeform : MonoBehaviour {

	// Use this for initialization
	Terrain terr;
	//int hmWidth;
	//int hmHeight;
	//heightmap height;

	int posXInTerrain;
	int posYInTerrain;

	void Start () {
		terr = Terrain.activeTerrain;
		//hmWidth = terr.terrainData.heightmapWidth;
		//hmHeight = terr.terrainData.heightmapHeight;
	}


	// Update is called once per frame
	void Update () {
		//get the normalized position of this game object relativee to the terrain
        //Vector3 tempCoord = getNormalizedPos(this.transform.position, terr);

        //get position on terrain
        Vector3 pos = GetRelativeTerrainPositionFromPos(this.transform.position, terr, terr.terrainData.heightmapWidth, terr.terrainData.heightmapHeight);
		
		
        //get the heights at this position                                  
		float[,] heights = Terrain.activeTerrain.terrainData.GetHeights((int)pos.x - (int)(GetComponent<Renderer>().bounds.size.x),
			                                                                (int)pos.z - (int)(GetComponent<Renderer>().bounds.size.z),
			                                                                (int)GetComponent<Renderer>().bounds.size.x + 2,
			                                                                (int)GetComponent<Renderer>().bounds.size.z + 2);
		Debug.Log ("x: " + ((int)pos.x - (int)(GetComponent<Renderer> ().bounds.size.x)) + " \nz:" + ((int)pos.z - (int)(GetComponent<Renderer> ().bounds.size.z)));
		Debug.Log ("x1:" + ( (int)GetComponent<Renderer>().bounds.size.x + 2)  + " \nz2:" + ((int)GetComponent<Renderer>().bounds.size.z + 2));
		Debug.Log ("heights size: " + heights.Length);
        //decrease the terrain height of where the object is by the height of the object
        Debug.Log("Size: " + this.GetComponent<Renderer>().bounds.size.x);
		for (int x = 0; x < (int)GetComponent<Renderer>().bounds.size.x; ++x)
        {
			for (int y = 0; y < (int)GetComponent<Renderer>().bounds.size.z; ++y)
            {
				Debug.Log("Pos: " + x + " " + y);
				heights[x, y] -= GetComponent<Renderer>().bounds.size.y + 100;
            }
        }


        terr.terrainData.SetHeights((int)pos.x - (int)GetComponent<Renderer>().bounds.size.x / 2 , (int)(pos.z) - (int)(GetComponent<Renderer>().bounds.size.z / 2), heights);
         
	}

    private Vector3 getNormalizedPos(Vector3 pos, Terrain ter)
    {
        Vector3 tempCoord = (pos - ter.gameObject.transform.position);
        Vector3 coord;

        coord.x = tempCoord.x / Terrain.activeTerrain.terrainData.size.x;
        coord.y = tempCoord.y / Terrain.activeTerrain.terrainData.size.y;
        coord.z = tempCoord.z / Terrain.activeTerrain.terrainData.size.z;

        return coord;
    }
    private Vector3 GetRelativeTerrainPositionFromPos(Vector3 pos, Terrain terrain, int mapWidth, int mapHeight)
    {
        Vector3 coord = getNormalizedPos(pos, terrain);
        // get the position of the terrain heightmap where this game object is
        return new Vector3((coord.x * mapWidth), 0, (coord.z * mapHeight));
    } 
}
