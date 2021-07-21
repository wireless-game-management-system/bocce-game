using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("BocceeBall"))
        {
            Debug.Log("Collision happened between the wall and the boccee");
        }
    }
}
