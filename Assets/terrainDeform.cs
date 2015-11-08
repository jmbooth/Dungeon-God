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

	public void Start () {Debug.Log ("deform");
		terr = Terrain.activeTerrain;

        //get position on terrain
        Vector3 pos = GetRelativeTerrainPositionFromPos(this.transform.position, terr, terr.terrainData.heightmapWidth, terr.terrainData.heightmapHeight);	
		
        //get the heights at this position                                  
		float[,] heights = Terrain.activeTerrain.terrainData.GetHeights((int)pos.x - (int)(GetComponent<BoxCollider>().bounds.size.x),
			                                                                (int)pos.z - (int)(GetComponent<BoxCollider>().bounds.size.z),
			                                                                (int)GetComponent<BoxCollider>().bounds.size.x + 2,
			                                                                (int)GetComponent<BoxCollider>().bounds.size.z + 2);

		Debug.Log ("x: " + ((int)pos.x - (int)(GetComponent<BoxCollider> ().bounds.size.x)) + " \nz:" + ((int)pos.z - (int)(GetComponent<BoxCollider> ().bounds.size.z)));
		Debug.Log ("x1:" + ( (int)GetComponent<BoxCollider>().bounds.size.x + 2)  + " \nz2:" + ((int)GetComponent<BoxCollider>().bounds.size.z + 2));
		Debug.Log ("heights size: " + heights.Length);

        //decrease the terrain height of where the object is by the height of the object
        Debug.Log("Size: " + this.GetComponent<BoxCollider>().bounds.size.x);
		for (int x = 0; x < heights.GetLength(1); ++x)
        {
			for (int y = 0; y < heights.GetLength(0); ++y)
            {
				Debug.Log("Pos: " + x + " " + y + "\nheight before:"+heights[x,y]);
				heights[x, y] -= GetComponent<BoxCollider>().bounds.size.y + 100;
				Debug.Log("height after:"+heights[x,y]);
            }
        }


        terr.terrainData.SetHeights((int)pos.x - (int)GetComponent<BoxCollider>().bounds.size.x / 2 , (int)(pos.z) - (int)(GetComponent<BoxCollider>().bounds.size.z / 2), heights);
         
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
