using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BocceBall : MonoBehaviour
{
    private Vector3 lastPosition;

    MeshRenderer defaultSetting;
    private Material matWhite;
    private Material defaultGameObjectMaterial;
    private GameObject currentGameObjectName;
    private bool touchedBoundary = false;
    void Start()
    {
        defaultSetting = GetComponent<MeshRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        defaultGameObjectMaterial = GameObject.Find("WestWall").GetComponent<MeshRenderer>().material;
    }

    void ResetMaterial()
    {
        currentGameObjectName.GetComponent<MeshRenderer>().material = defaultGameObjectMaterial;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "WestWall")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Collsion happened at WestWall");
            touchedBoundary = true;
            collision.gameObject.GetComponent<Renderer>().material = matWhite;
            currentGameObjectName = collision.gameObject;
            Invoke("ResetMaterial", .3f);
        }

        if (collision.gameObject.name == "EastWall")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Collsion happened at EastWall");
            touchedBoundary = true;
            collision.gameObject.GetComponent<Renderer>().material = matWhite;
            currentGameObjectName = collision.gameObject;
            Invoke("ResetMaterial", .3f);
        }

        if (collision.gameObject.name == "NorthWall")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Collsion happened at NorthWall");
            touchedBoundary = true;
            collision.gameObject.GetComponent<Renderer>().material = matWhite;
            currentGameObjectName = collision.gameObject;
            Invoke("ResetMaterial", .3f);
        }

        if (collision.gameObject.name == "SouthWall")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Collsion happened at SouthWall");
            touchedBoundary = true;
            collision.gameObject.GetComponent<Renderer>().material = matWhite;
            currentGameObjectName = collision.gameObject;
            Invoke("ResetMaterial", .3f);
        }
    }

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
                    case "EastWall":
                        if (transform.position.x > gameObject.transform.position.x)
                        { 
                            return false; 
                        }
                        if(touchedBoundary)
                        {
                            return false;
                        }
                        break;
                    case "WestWall":
                        if (transform.position.x < gameObject.transform.position.x)
                        {
                            return false;
                        }
                        if (touchedBoundary)
                        {
                            return false;
                        }
                        break;
                    case "NorthWall":
                        if (transform.position.z > gameObject.transform.position.z)
                        {
                            return false;
                        }
                        if (touchedBoundary)
                        {
                            return false;
                        }
                        break;
                    case "SouthWall":
                        if (transform.position.z < gameObject.transform.position.z)
                        {
                            return false;
                        }
                        if (touchedBoundary)
                        {
                            return false;
                        }
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