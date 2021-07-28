using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using UnityEngine.SceneManagement;
using Firebase.Unity;
using Firebase.Database;

public class controller2 : MonoBehaviour

{
    DatabaseReference reference;
    string todaysDate;
    [SerializeField]
    private InputField input;
     [SerializeField]
    private InputField input1;
     [SerializeField]
    private InputField input2;
    [SerializeField]
    private GameObject BUtton1;
    [SerializeField]
    private Text display0;
    [SerializeField]
    private Text display;
    [SerializeField]
    private Text display1;
     [SerializeField]
    private Text display2;
     [SerializeField]
    private Text display8;
     [SerializeField]
    private Text display9; 
   
    // Start is called before the first frame update
    void Start()
    {
        display.text=  DateTime.Now.ToString("HH:mm:ss tt");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        todaysDate = DateTime.Now.ToString("MMMM-dd-yyyy");
    }

    // Update is called once per frame
    public void Update()

    {

        
       if (input.text!="")
    
    
       {
        PlayerPrefs.SetString("team1", input1.text);
        PlayerPrefs.SetString("team2", input2.text);
        int y= Int32.Parse(input.text);
        int minutes= y % 60;
        int hours=y/60;
        display2.text= hours.ToString("00")+ ':' +minutes.ToString("00");
         PlayerPrefs.SetString("time", display2.text);
       }
        int x=0;
        if (input.text=="")
        {x++;}
         if (input1.text=="")
        {x++;}
         if (input2.text=="")
        {x++;} 

         if (Input.GetKeyDown(KeyCode.LeftArrow)) {  
            SceneManager.LoadScene("screen1"); 
         }
            if (x==0)
            {
            if (Input.GetKeyDown(KeyCode.RightArrow)) 
            {
                string TeamVsTeam = input1.text + " vs " + input2.text;
                SceneManager.LoadScene("screen3");
                
               // reference.Child("Game").SetValueAsync(todaysDate);
               // reference.Child("Game").Child(todaysDate).SetValueAsync(TeamVsTeam);
            }
        }

           
            else {display0.text="All fields must be filled";}

       

    }
    
    


}
