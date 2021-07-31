using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Unity;


public class controller2 : MonoBehaviour

{

    [SerializeField]
    public InputField input;
     [SerializeField]
    public InputField input1;
     [SerializeField]
    public InputField input2;
    //[SerializeField]
    //private GameObject BUtton1;
    [SerializeField]
    public Text display0;
    [SerializeField]
    public Text display;
    [SerializeField]
    public Text display1;
     [SerializeField]
    public Text display2;
     [SerializeField]
    public Text display8;
     [SerializeField]
    public Text display9;

    public InputField teamName;
    public InputField teamName2;
    public InputField playerName1;
    public InputField playerName2;

    DateTime dateTime = DateTime.Now;
    string todaysDate;


    public Button saveButton;

  

    // Start is called before the first frame update
    void Start()
    {
     
        display.text=  DateTime.Now.ToString("HH:mm:ss tt");
    }

    // Update is called once per frame
    public void Update()
    {
       if (input.text!="")
       {
        
        int y= Int32.Parse(input.text);
        int minutes= y % 60;
        int hours=y/60;
        display2.text= hours.ToString("00")+ ':' +minutes.ToString("00");
       }
        int x=0;
        if (input.text=="")
        {x++;}
         if (input1.text=="")
        {x++;}
         if (input2.text=="")
        {x++;} 

         if (Input.GetKey (KeyCode.P)) {  
            SceneManager.LoadScene("screen1"); 
         }
            if (x==0)
            {
                 if (Input.GetKey (KeyCode.N)) {  
            SceneManager.LoadScene("screen3"); 
            }}

           
            else {display0.text="All fields must be filled";}

       

    }
    
    


}
