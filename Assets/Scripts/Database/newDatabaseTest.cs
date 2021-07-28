using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity;
using Firebase.Database;
using UnityEngine.UI;
using System;

public class newDatabaseTest : MonoBehaviour
{
    DatabaseReference reference;
    public InputField teamName;
    public InputField teamName2;
    public InputField playerName1;
    public InputField playerName2;
    public InputField ballLocation;
    public InputField ballLocation2;
    public Text showData;

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

        string TeamVsTeam = teamName.text + " vs " + teamName2.text;
        reference.Child("Game").Child("Date").SetValueAsync(todaysDate);
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").SetValueAsync(TeamVsTeam);
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).SetValueAsync(teamName.text.ToString());
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).SetValueAsync(teamName2.text.ToString());
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).Child(teamName.text.ToString()).Child("Player Name:").SetValueAsync(playerName1.text.ToString());
        reference.Child("Game").Child("Date").Child(todaysDate).Child("Team vs Team").Child(TeamVsTeam).Child(teamName2.text.ToString()).Child("Player Name:").SetValueAsync(playerName2.text.ToString());

    }

    public void LoadData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Users").ValueChanged += NewDatabaseTest_ValueChanged;
    }

    private void NewDatabaseTest_ValueChanged(object sender, ValueChangedEventArgs e)
    {
       // Debug.Log("Data retrieved from DB Team Name: " + e.Snapshot.Child("user 2").Child("Team Name").GetValue(true).ToString());
       // Debug.Log("Data retrieved from DB Player 1: " + e.Snapshot.Child("user 2").Child("Team Name").Child("Player 1").GetValue(true).ToString());
       // Debug.Log("Data retrieved from DB Ball Location 1: " + e.Snapshot.Child("user 2").Child("Team Name").Child("Player 1").Child("Ball Location 1").GetValue(true).ToString());
       // Debug.Log("Data retrieved from DB Team Name: " + e.Snapshot.Child("user 2").Child("Team Name").Child("Player 2").GetValue(true).ToString());
       // showData.text = e.Snapshot.Child("user 2").Child("Team Name").Child("Player 2").GetValue(true).ToString();
    }
}
