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

      //Debug.Log(this.transform.position + "\n");
      //Debug.Log(terr.gameObject.transform.position + "\n");
      //Debug.Log(tempCoord);
		Vector3 coord;
		coord.x = tempCoord.x / terr.terrainData.size.x;
		coord.y = tempCoord.y / terr.terrainData.size.y;
		coord.z = tempCoord.z / terr.terrainData.size.z;

		//get the position of the terrain heightmap where this game object is
		posXInTerrain = (int)(coord.x * hmWidth);
		posYInTerrain = (int)(coord.z * hmHeight);

		//set an offset so that all the raising terrain is under this game object
		int offset = size / 2;

		//get the heights of the terrain under this game object
		float[,] heights = terr.terrainData.GetHeights ((posXInTerrain - offset), (posYInTerrain - offset), size, size);

        Debug.Log(heights);
		//we set each sample of the terrain in the size to the desired height
		for (int i=0; i < size; i++)
			for (int j=0; j < size; j++)
				heights [i, j] = desiredHeight;
        Debug.Log(desiredHeight);

       
		//set new terrain
		terr.terrainData.SetHeights (posXInTerrain - offset, posYInTerrain - offset, heights);
    
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
