using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cube : MonoBehaviour
{
    public enum Type
    {
        Wall,
        Floor,
        Start,
        Goal
    }

    public Type cubeType = Type.Floor;

    /*private void OnValidate()
    {
        switch (cubeType)
        {
            case Type.Wall:
                this.GetComponentInChildren<Renderer>().sharedMaterial.color = Color.black;
                this.transform.GetChild(0).gameObject.transform.localScale = new Vector3(1, 3, 1);
                this.transform.GetChild(0).gameObject.transform.position = new Vector3(this.transform.GetChild(0).gameObject.transform.position.x - 0.01f, 1.5f, this.transform.GetChild(0).gameObject.transform.position.z - 0.01f);
                break;
            case Type.Floor:
                this.GetComponentInChildren<Renderer>().sharedMaterial.color = Color.white;
                this.transform.GetChild(0).gameObject.transform.localScale = new Vector3(1, 1, 1);
                this.transform.GetChild(0).gameObject.transform.position = new Vector3(this.transform.GetChild(0).gameObject.transform.position.x - 0.01f, 0.5f, this.transform.GetChild(0).gameObject.transform.position.z - 0.01f);
                break;
            case Type.Start:
                this.GetComponentInChildren<Renderer>().sharedMaterial.color = Color.green;
                this.transform.GetChild(0).gameObject.transform.localScale = new Vector3(1, 1, 1);
                this.transform.GetChild(0).gameObject.transform.position = new Vector3(this.transform.GetChild(0).gameObject.transform.position.x - 0.01f, 0.5f, this.transform.GetChild(0).gameObject.transform.position.z - 0.01f);
                break;
            case Type.Goal:
                this.GetComponentInChildren<Renderer>().sharedMaterial.color = Color.red;
                this.transform.GetChild(0).gameObject.transform.localScale = new Vector3(1, 1, 1);
                this.transform.GetChild(0).gameObject.transform.position = new Vector3(this.transform.GetChild(0).gameObject.transform.position.x - 0.01f, 0.5f, this.transform.GetChild(0).gameObject.transform.position.z - 0.01f);
                break;
        }
    }*/
}
