using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using UnityEngine.SceneManagement;
public class controller0 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
     private GameObject btn;
    
   public void next_screen()
    {
       
        float distance_B1=Vector3.Distance( GameObject.Find("Blue1").transform.position,  GameObject.Find("King Ball").transform.position);
        float distance_B2=Vector3.Distance( GameObject.Find("Blue2").transform.position,  GameObject.Find("King Ball").transform.position);
        float distance_B3=Vector3.Distance( GameObject.Find("Blue3").transform.position,  GameObject.Find("King Ball").transform.position);
        float distance_R1=Vector3.Distance( GameObject.Find("Red1").transform.position,  GameObject.Find("King Ball").transform.position);
        float distance_R2=Vector3.Distance( GameObject.Find("Red2").transform.position,  GameObject.Find("King Ball").transform.position);
        float distance_R3=Vector3.Distance( GameObject.Find("Red3").transform.position,  GameObject.Find("King Ball").transform.position);
       
       //SceneManager.LoadScene("screen2");
    }

   
}
