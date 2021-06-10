using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySidesAndDown : MonoBehaviour
{
    public float minDistanceFromWall = 0.6f;
    private RaycastHit hitInfo;
    public bool CanGoLeft()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitInfo))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left), Color.yellow);
            if (hitInfo.distance <= minDistanceFromWall)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }        
    }
    public bool CanGoRight()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitInfo))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.yellow);
            if (hitInfo.distance <= minDistanceFromWall)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }
    public bool CanGoForward()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.yellow);
            if (hitInfo.distance <= minDistanceFromWall)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }
    public bool CanGoBack()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hitInfo))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back), Color.yellow);
            if (hitInfo.distance <= minDistanceFromWall)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    public bool StandingOnGoal()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hitInfo))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back), Color.yellow);
            if (hitInfo.collider.gameObject.tag == "Goal")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
