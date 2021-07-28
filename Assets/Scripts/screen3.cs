using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using UnityEngine.SceneManagement;
using Firebase.Database;

public class screen3 : MonoBehaviour
{
    string todaysDate;
    DatabaseReference reference;
    [SerializeField]
    private InputField input1;
     [SerializeField]
    private InputField input2;
     [SerializeField]
    private InputField input3;
     [SerializeField]
    private InputField input4;
     [SerializeField]
    private InputField input5;
     [SerializeField]
    private InputField input6;
     [SerializeField]
    private InputField input7;
     [SerializeField]
    private InputField input8;
     [SerializeField]
    private Text Team1;
     [SerializeField]
    private Text Team2;

    // Start is called before the first frame update
    void Start()
    {
        Team1.text=PlayerPrefs.GetString("team1");
        Team2.text=PlayerPrefs.GetString("team2");
        todaysDate = DateTime.Now.ToString("MMMM-dd-yyyy");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {

      
        PlayerPrefs.SetString("player1_team1", input1.text);
         PlayerPrefs.SetString("player2_team1", input2.text);
          PlayerPrefs.SetString("player3_team1", input3.text);
           PlayerPrefs.SetString("player4_team1", input4.text);
           PlayerPrefs.SetString("player1_team2", input5.text);
            PlayerPrefs.SetString("player2_team2", input6.text);
             PlayerPrefs.SetString("player3_team2", input7.text);
              PlayerPrefs.SetString("player4_team2", input8.text);
          if (Input.GetKeyDown(KeyCode.LeftArrow)) {  
            SceneManager.LoadScene("screen2"); 
    }
          if (Input.GetKeyDown(KeyCode.RightArrow)) {  
           // SceneManager.LoadScene("Bocce"); 
    }
    }

    public void onSubmit()
    {
        string[] teamOnePlayer = {input1.text, input2.text, input3.text, input4.text };
        string[] teamTwoPlayer = { input5.text, input6.text, input7.text, input8.text }; 
        string TeamVsTeam = Team1.text + " vs " + Team2.text;

        for (int i = 0; i<teamOnePlayer.Length; i++)
        {
            reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).Child(Team1.text.ToString()).Child(teamOnePlayer[i]).SetValueAsync("");
        }
        for (int i = 0; i < teamTwoPlayer.Length; i++)
        {
            reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).Child(Team2.text.ToString()).Child(teamTwoPlayer[i]).SetValueAsync("");
        }

        SceneManager.LoadScene("Bocce");
    }

}
