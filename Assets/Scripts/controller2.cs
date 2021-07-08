using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using UnityEngine.SceneManagement;

public class controller2 : MonoBehaviour

{

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
    }

    // Update is called once per frame
    public void Update()
    {
       
        int x= Int32.Parse(input.text);
        int minutes= x % 60;
        int hours=x/60;
        display2.text= hours.ToString("00")+ ':' +minutes.ToString("00");



    }
    public void play()
    {
        int x=0;
        if (input.text=="")
        {x++;}
         if (input1.text=="")
        {x++;}
         if (input2.text=="")
        {x++;} 
        
            if (x==0)

            {SceneManager.LoadScene("screen0");}
            else {display0.text="All fields must be filled";}

    }
}
