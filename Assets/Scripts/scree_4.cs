using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scree_4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {  
            SceneManager.LoadScene("Bocce"); 
         }
              if (Input.GetKeyDown(KeyCode.RightArrow)) {  
            SceneManager.LoadScene("screen5"); 
         }
        
    }
}
