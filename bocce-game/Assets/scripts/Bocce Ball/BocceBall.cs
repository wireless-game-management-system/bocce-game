using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BocceBall : MonoBehaviour
{
    private Vector3 lastPosition;
    public bool IsMoving
    {
        get
        {
            bool isMoving = false;
            if (GetComponent<Rigidbody>().velocity.magnitude > 0.05f)
                isMoving = true;
            if (GetComponent<Rigidbody>().angularVelocity.magnitude > 0.05f)
                isMoving = true;
            return isMoving;
        }
    }
    
    public bool InBounds
    {
        get
        {
            IEnumerable<GameObject> gameObjects = GameObject.FindGameObjectsWithTag("BoundaryWall");
            foreach (GameObject gameObject in gameObjects)
            {
                switch (gameObject.name)
                {
                    case "East Wall":
                        if (transform.position.x > gameObject.transform.position.x)
                            return false;
                        break;
                    case "West Wall":
                        if (transform.position.x < gameObject.transform.position.x)
                            return false;
                        break;
                    case "North Wall":
                        if (transform.position.z > gameObject.transform.position.z)
                            return false;
                        break;
                    case "South Wall":
                        if (transform.position.z < gameObject.transform.position.z)
                            return false;
                        break;
                }
            }
            return true;
        }
    }
    
    public float VelocityDamp = 0.025f;
    public float AngularVelocityDamp = 0.025f;
    
    [HideInInspector]
    public int
        Team;

    void OnCollisionStay()
    {

        if (IsMoving)
        {
            GetComponent<Rigidbody>().velocity *= 1 - VelocityDamp;
            GetComponent<Rigidbody>().angularVelocity *= 1 - AngularVelocityDamp;
        }
        else
        {
            GetComponent<Rigidbody>().velocity *= 0;
            GetComponent<Rigidbody>().angularVelocity *= 0;
        }
    }
    
    public float GetDistanceSqToPoint(Vector3 position_)
    {        
        return (transform.position - position_).sqrMagnitude;
    }
}