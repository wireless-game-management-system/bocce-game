using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_R2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey (KeyCode.T)) {  
            transform.Translate (0f, 0f, 0.01f); 
    }
}
}