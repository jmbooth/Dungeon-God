using UnityEngine;
using System.Collections;

public class terrainDeform : MonoBehaviour {

	// Use this for initialization
	Terrain terr;
	int hmWidth;
	int hmHeight;
	//heightmap height;

	int posXInTerrain;
	int posYInTerrain;

	int size = 50;
	float desiredHeight = 0;

	void Start () {
		terr = Terrain.activeTerrain;
		hmWidth = terr.terrainData.heightmapWidth;
		hmHeight = terr.terrainData.heightmapHeight;
	}
	
	// Update is called once per frame
	void Update () {
		//get the normalized position of this game object relativee to the terrain
        Vector3 tempCoord = getNormalizedPos(this.transform.position, terr);

        //get position on terrain
        Vector3 pos = GetRelativeTerrainPositionFromPos(this.transform.position, terr, terr.terrainData.heightmapWidth, terr.terrainData.heightmapHeight);

        Renderer renderer = GetComponent("renderer") as Renderer;

        //get the heights at this position                                  
        float[,] heights = Terrain.activeTerrain.terrainData.GetHeights((int)pos.x - (int)(renderer.bounds.size.x / 2),
                                                                           (int)pos.z - (int)(renderer.bounds.size.z / 2),
                                                                           (int)renderer.bounds.size.x + 1,
                                                                           (int)renderer.bounds.size.z + 1);

        //increase the heights where this is by 1 500th of the size of the cube.
        //Debug.Log("Size: " + this.renderer.bounds.size.x);
        for (int x = 0; x < (int)renderer.bounds.size.x; ++x)
        {
            for (int y = 0; y < (int)renderer.bounds.size.z; ++y)
            {
                heights[x, y] += renderer.bounds.size.y / 750;
            }

        }


        terr.terrainData.SetHeights((int)pos.x - (int)renderer.bounds.size.x / 2 , (int)(pos.z) - (int)(renderer.bounds.size.z / 2), heights);
         
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
