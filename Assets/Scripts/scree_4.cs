using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using Firebase;
using Firebase.Database;
public class scree_4 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Text Text;
     [SerializeField]
    public Text winning;
     [SerializeField]
    public Text looser;
     [SerializeField]
    public Text finalscore;
     [SerializeField]
    public Text matchwinner;

    DatabaseReference reference;
    DateTime dateTime = DateTime.Now;
    string todaysDate;
    public Button submit;
    public Button getScore;
    public Text firstTeam;
    public Text secondTeam;
    public Text total;
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        todaysDate = dateTime.ToString("MMMM-dd-yyyy");
        Text.text= PlayerPrefs.GetString("gamecount");
    string [] team= new string[2] {PlayerPrefs.GetString("team1"),PlayerPrefs.GetString("team2")};

        winning.text = team[Int32.Parse(PlayerPrefs.GetString("winningteam"))];
        looser.text= team[Int32.Parse(PlayerPrefs.GetString("losingteam"))];
        matchwinner.text=team[Int32.Parse(PlayerPrefs.GetString("winningteam"))];

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

    public void saveScore()
    {
        string TeamVsTeam = screen3.team1.text + " vs " + screen3.team2.text;
        reference.Child("Game").Child("Date").SetValueAsync(todaysDate);
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").SetValueAsync(TeamVsTeam);
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).SetValueAsync(screen3.team1.text.ToString());
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).SetValueAsync(screen3.team2.text.ToString());
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).Child(screen3.team1.text.ToString()).SetValueAsync(winning.text.ToString());
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).Child(screen3.team1.text.ToString()).SetValueAsync(looser.text.ToString());
        reference.Child("Game").Child("Data").Child(todaysDate).Child("Highest Score").SetValueAsync(matchwinner.text.ToString()); 

    }

    public void LoadScore()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Game").ValueChanged += Script_ValueChanged;
    }

    private void Script_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        string TeamVsTeam = screen3.team1.text + " vs " + screen3.team2.text;
        firstTeam.text = e.Snapshot.Child("Data").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).Child(screen3.team1.text.ToString()).GetValue(true).ToString();
        secondTeam.text = e.Snapshot.Child("Data").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).Child(screen3.team2.text.ToString()).GetValue(true).ToString();
        total.text = e.Snapshot.Child("Data").Child(todaysDate).Child("Highest Score").GetValue(true).ToString();
    }

}
