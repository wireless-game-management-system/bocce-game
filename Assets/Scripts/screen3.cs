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

public class screen3 : MonoBehaviour
{
    DatabaseReference reference;

    public static InputField team1;
    public static InputField team2;
    public InputField p1;
    public InputField p2;
    public InputField p3;
    public InputField p4;
    public InputField p5;
    public InputField p6;
    public InputField sub1;
    public InputField sub2;
    public InputField sub3;
    public InputField sub4;
    public InputField p7;
    public InputField p8;
    public InputField p9;
    public InputField p10;
    public InputField p11;
    public InputField p12;
    public InputField sub5;
    public InputField sub6;
    public InputField sub7;
    public InputField sub8;

    public Button submit;

    DateTime dateTime = DateTime.Now;
    string todaysDate;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        todaysDate = dateTime.ToString("MMMM-dd-yyyy");

    }

    public void saveData()
    {
        string TeamVsTeam = team1.text + " vs " + team2.text;
        reference.Child("Game").Child("Date").SetValueAsync(todaysDate);
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").SetValueAsync(TeamVsTeam);
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).SetValueAsync(team1.text.ToString());
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).SetValueAsync(team2.text.ToString());
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).Child(team1.text.ToString()).Child("Player Name:").SetValueAsync(p1.text.ToString() + ", " + p2.text.ToString()
         + ", " + p3.text.ToString() + ", " + p4.text.ToString() + ", " + p5.text.ToString() + ", " + p6.text.ToString());
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).Child(team2.text.ToString()).Child("Player Name:").SetValueAsync(p7.text.ToString() + ", " + p8.text.ToString()
         + ", " + p9.text.ToString() + ", " + p10.text.ToString() + ", " + p11.text.ToString() + ", " + p12.text.ToString());
    }


    // Update is called once per frame
    void Update()
    {
         if (Input.GetKey (KeyCode.P)) {  
            SceneManager.LoadScene("screen2"); 
    }
         if (Input.GetKey (KeyCode.KeypadEnter)) {  
            SceneManager.LoadScene("Bocce"); 
    }
    }
}
