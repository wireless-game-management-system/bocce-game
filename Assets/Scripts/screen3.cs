using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using UnityEngine.SceneManagement;

public class screen3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.LeftArrow)) {  
            SceneManager.LoadScene("screen2"); 
    }
          if (Input.GetKeyDown(KeyCode.RightArrow)) {  
            SceneManager.LoadScene("Bocce"); 
    }
    }
}
