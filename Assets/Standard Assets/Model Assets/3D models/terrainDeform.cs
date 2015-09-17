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
		Vector3 tempCoord = (transform.position - terr.gameObject.transform.position);
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

		//we set each sample of the terrain in the size to the desired height
		for (int i=0; i < size; i++)
			for (int j=0; j < size; j++)
				heights [i, j] = desiredHeight;
		//set new terrain
		terr.terrainData.SetHeights (posXInTerrain - offset, posYInTerrain - offset, heights);
	}
}
