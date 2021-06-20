using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_R1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey (KeyCode.R)) {  
            transform.Translate (0f, 0f, 0.01f); 
    }
}
}