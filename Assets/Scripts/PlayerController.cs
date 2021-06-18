using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 10f;

    private float xInput;
    private float yInput;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProccessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProccessInputs() {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    private void Move() {
        rb.AddForce(new Vector3(xInput, 0f, yInput) * moveSpeed);
    }
}
