using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using Firebase;
using Firebase.Database;
using Proyecto26;


public class scree_4 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Text Text;
     [SerializeField]
    public Text winning;
     [SerializeField]
    public Text looser;
    
    public Text finalscore;
    public Button submit;
    public Button getInfo;
    public Text showInfo;
    public static Text secondTeam;
    public static Text total;
    public static string player1;
    public static string player2;
    public InputField t1;
    public InputField t2;
    public InputField p1;
    public InputField p2;
    public InputField b1;
    public InputField b2;
    public static int playcount;
    public static int ballP;
    public static int ballP2;
    public static int totalScore;
    public static string teamA;
    public static string teamB;
    public Text game;
    Team team = new Team();
    
    void Start()
    {
        
        playcount = 2;
        game.text = playcount.ToString();
        finalscore.text = playcount.ToString();
        ballP++;
        ballP2++;
        /*
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        todaysDate = dateTime.ToString("MMMM-dd-yyyy");
       
        Text.text= PlayerPrefs.GetString("gamecount");
    string [] team= new string[2] {PlayerPrefs.GetString("team1"),PlayerPrefs.GetString("team2")};
        
        winning.text = team[Int32.Parse(PlayerPrefs.GetString("winningteam"))];
        looser.text= team[Int32.Parse(PlayerPrefs.GetString("losingteam"))];
        matchwinner.text=team[Int32.Parse(PlayerPrefs.GetString("winningteam"))];
     */   
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

    public void onSave()
    {
        teamA = t1.text;
        teamB = t2.text;
        player1 = p1.text;
        player2 = p2.text;
        /*
        ballP = int.Parse(b1.text);
        ballP2 = int.Parse(b2.text);
        */
        totalScore = int.Parse(finalscore.text) * 2;
        //finalscore.text = totalScore.ToString();
        saveData();
        
    }

    public void saveData()
    {

        Team team = new Team();
        
        RestClient.Put("https://unity-game-767f2-default-rtdb.firebaseio.com/" + game.text + ".json", team);

        /*
        string TeamVsTeam = t1.text + " vs " + t2.text;
        reference.Child("Game").Child("Date").SetValueAsync(todaysDate);
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").SetValueAsync(TeamVsTeam);
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).SetValueAsync(t1.text.ToString());
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).SetValueAsync(t2.text.ToString());
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).Child(t1.text.ToString()).Child("Team 1 player").SetValueAsync(p1.text.ToString());
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).Child(t2.text.ToString()).Child("Team 2 player").SetValueAsync(p2.text.ToString());

        
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).Child(screen3.team1.text.ToString()).SetValueAsync(winning.text.ToString());
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).Child(screen3.team1.text.ToString()).SetValueAsync(looser.text.ToString());
        reference.Child("Game").Child("Data").Child(todaysDate).Child("Highest Score").SetValueAsync(matchwinner.text.ToString()); 
        */
    }

   
    public void LoadScore()
    {
        /*
        RestClient.Get<Team>("" + team + ".json").Then(onResolved: response =>
        {
            team = response;
            showInfo.text = "Informaton: " + response.ToString();
        });*/

        
        RestClient.Get("https://unity-game-767f2-default-rtdb.firebaseio.com/" + game.text + ".json").Then(response =>
        {

            
            showInfo.text = "Team Info: " + response.Text;
           /*
            + " " + response.Text.Substring(user.UserScore) + " " + response.Text.Substring(int.Parse(user.TeamName))
                + " " + response.Text.Substring(int.Parse(user.TeamMateName)) + " " + response.Text.Substring(user.BallLocation);

            
            string json = response.Text.Trim();
            showData.text = json;
            */



        });
        
        /*
        FirebaseDatabase.DefaultInstance.GetReference("Game").GetValueAsync().ContinueWith(response =>
          {
              if  (response.IsFaulted)
              {
                  Debug.Log("failed");
              // Handle the error...
          }
              else if (response.IsCompleted)
              {
                  DataSnapshot snapshot = response.Result;

                  string s = JsonUtility.ToJson(snapshot.Value.ToString());
                  firstTeam.text = s;
                  Debug.Log(s);
          }
          });*/
    }
    /*
    public void LoadScore()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Game").ValueChanged += Script_ValueChanged;
    }
    
    private void Script_ValueChanged(object sender, ValueChangedEventArgs e)
    {


        
        string TeamVsTeam = t1.text + " vs " + t2.text;
        firstTeam.text = e.Snapshot.Child("Date").Child("Team vs Team").Child("Team 1 player").GetValue(true).ToString() + " ";//.Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).Child(screen3.team1.text.ToString()).GetValue(true).ToString();
        secondTeam.text = e.Snapshot.Child("Data").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).Child(screen3.team2.text.ToString()).GetValue(true).ToString();
        total.text = e.Snapshot.Child("Data").Child(todaysDate).Child("Highest Score").GetValue(true).ToString();
    }*/

}
