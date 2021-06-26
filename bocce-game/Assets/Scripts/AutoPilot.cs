using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPilot : MonoBehaviour
{
    public Rigidbody rd;
    public float moveSpeed = 10f;

    private float xInput;
    private float yInput;
    private float zInput;

    private float maxValueX = 5f;
    private float minValueX = -5f;
    private float minValueZ = 7.5f;
    private float maxValueZ = 15f;

    void Start()
    {
        RandomCoordinates();
        transform.position = transform.position + new Vector3(xInput, yInput, zInput);
        Debug.Log(transform.position);
        Debug.Log(PlayerPrefs.GetInt("totalPlayer"));
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void RandomCoordinates() {
        xInput = Random.Range(minValueX, maxValueX);
        zInput = Random.Range(minValueZ, maxValueZ);
        yInput = 4.5f;
    }
}
