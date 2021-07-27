using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using UnityEngine.SceneManagement;


public class controller : MonoBehaviour
{   [SerializeField]
    private InputField input;
    [SerializeField]
    private GameObject btn;
    [SerializeField]
    private Text Text;
    [SerializeField]
    private Text Text2;
    [SerializeField]
    private Text Text3;
    [SerializeField]
    private Text Text4;
     [SerializeField]
    private Text Text5;
    
    public void Awake()

    {
        // DontDestroyOnLoad(gameObject);
         Text5.text=  DateTime.Today.ToString("MM/dd/yyyy");
        
    } 
     public void display()
    {
         if (input.text =="123")
        {
            Text.text="BELAIRE BEACH CLUB";
            Text2.text="DRAGONS";
            Text3.text="CASA";
            Text4.text="LDV";
            
            btn.SetActive(false);   
           // PlayerPrefs.SetString("team1",Text3.text);
           // PlayerPrefs.SetString("team2",Text4.text);

        }
         
   
    }
    void Update()
    {  
         
         if (input.text =="123")
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {  
            SceneManager.LoadScene("screen2"); 
    }
}

}

       
}