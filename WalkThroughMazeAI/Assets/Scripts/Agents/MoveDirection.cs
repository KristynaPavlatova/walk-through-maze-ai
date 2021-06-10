using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirection : MonoBehaviour
{
    public float moveForce = 0.0f;
    public Vector3 moveDir;
    private Rigidbody _rBody;
    private const int STEP_LENGTH = 1;

    private void Awake()
    {
        _rBody = this.GetComponent<Rigidbody>();
                Debug.Assert(_rBody, "Agent is missing RigidBody component!");
    }

    public void MoveDir(int pDir)
    {
        switch (pDir)
        {
            case (int)DirectionsEnum.Directions.Left:
                this._rBody.MovePosition(new Vector3(this.transform.position.x + STEP_LENGTH, this.transform.position.y, this.transform.position.z));
                break;
            case (int)DirectionsEnum.Directions.Right:
                this._rBody.MovePosition(new Vector3(this.transform.position.x - STEP_LENGTH, this.transform.position.y, this.transform.position.z));
                break;
            case (int)DirectionsEnum.Directions.Forward:
                this._rBody.MovePosition(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - STEP_LENGTH));
                break;
            case (int)DirectionsEnum.Directions.Back:
                this._rBody.MovePosition(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + STEP_LENGTH));
                break;
        }
        
    }
}
