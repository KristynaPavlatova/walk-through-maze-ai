using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpawnPrefabGrid : MonoBehaviour
{
    public GameObject[] cubes;
    public int gridX;
    public int gridZ;
    public Vector3 gridOrigin = Vector3.zero;

    public void FindBuildingBlocks()
    {
        cubes = new GameObject[] { GameObject.FindGameObjectWithTag("wall") , GameObject.FindGameObjectWithTag("floor")};
        foreach (GameObject o in cubes)
        {
            Debug.Assert(o, "There are no gameObjects with the right tags to find all cubes prefabs in the scene!");
        }
    }
    public void SpawnGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                Debug.Log("x " + x + ", z " + z);
                GameObject block = Instantiate(cubes[0], new Vector3(x, 0, z) + gridOrigin, Quaternion.identity);
                
            }
        }
    }    
}
