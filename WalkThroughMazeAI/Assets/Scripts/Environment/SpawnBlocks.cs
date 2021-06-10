using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject block;
    public int gridX;
    public int gridZ;
    public float offset = 1;
    public Vector3 origin = Vector3.zero;
    public Material[] materials = new Material[4];
    // Start is called before the first frame update
    void Start()
    {
        SpawnGrid();
    }
    private void Update()
    {
        ChangeColor();
    }
    private void SpawnGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                Vector3 spawnPos = new Vector3(x * offset, 0, z * offset) + origin;
                GameObject clone = Instantiate(block, spawnPos, Quaternion.identity);
                clone.transform.SetParent(this.transform);
            }
        }
    }
    private void ChangeColor()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponentInChildren<Cube>().cubeType == Cube.Type.Wall)
            {
                child.GetComponent<Renderer>().material = materials[0];
                child.transform.gameObject.transform.localScale = new Vector3(1, 4, 1);
            }
            if (child.GetComponentInChildren<Cube>().cubeType == Cube.Type.Floor)
            {
                child.GetComponent<Renderer>().material = materials[1];
                child.transform.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if (child.GetComponentInChildren<Cube>().cubeType == Cube.Type.Goal)
            {
                child.GetComponent<Renderer>().material = materials[2];
                child.transform.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if (child.GetComponentInChildren<Cube>().cubeType == Cube.Type.Start)
            {
                child.GetComponent<Renderer>().material = materials[3];
                child.transform.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
