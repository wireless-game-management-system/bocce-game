using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;


public class DatabaseTest : MonoBehaviour
{
    
    public Text score;
    public InputField username;
    public InputField teamname;
    public InputField teamMateName;
    public InputField ballLocationText;
    public Text storedUsername;

    private System.Random random = new System.Random();

    User user = new User();

    public static int playerScore;
    public static string playerName;
    public static string teamMate;
    public static string teamName;
    public static int ballLocation;
    public static string storedName;
    

    void start()
    {
        playerScore = random.Next(1, 101);
        score.text = "You score: " + playerScore;
    }

    public void onSubmitBtn()
    {
        playerName = username.text;
        teamName = teamname.text;
        teamMate = teamMateName.text;
        ballLocation = int.Parse(ballLocationText.text);

        PostToDatabase();
    }

    public void onGetInfoBtn()
    {
        
        ReadFromDB();
    }

    private void PostToDatabase()
    {
        User user = new User();
        RestClient.Put("https://unity-game-767f2-default-rtdb.firebaseio.com/" + playerName + ".json",  user);
    }

    private void ReadFromDB()
    {
        RestClient.Get<User>("https://unity-game-767f2-default-rtdb.firebaseio.com/" + username.text + ".json").Then(response =>
        {
            user = response;
            UpdateInfo();
        });

    }

    private void UpdateInfo()
    {
        storedUsername.text = user.UserName ;
        //score.text = "Your score is: " + user.UserScore;
    }

    // Start is called before the first frame update
    /*
    void Start()
    {
        //reference = FirebaseDatabase.DefaultInstance.RootReference;


        playerScore = random.Next(0, 100);
        score.text = "Your Score: " + playerScore;
        
    }
    
    public void pushData()
    {
        User user = new User();
        user.UserName = username.text;
        user.UserScore = int.Parse(score.text);
        user.TeamName = teamname.text;
        user.TeamMateName = teamMateName.text;
        

        string json = JsonUtility.ToJson(user);

        reference.Child("User").Child(user.UserName).SetRawJsonValueAsync(json).ContinueWith(task => {

            if (task.IsCompleted)
            {
                Debug.Log(json);
            }
        
        });

    }
    
    public void onSubmit() 
    {
        playerName = username.text;
        teamName = teamname.text;
        teamMate = teamMateName.text;
        ballLocation = int.Parse(ballLocationText.text);

        PostToDatabase();
    }

    private void PostToDatabase()

    {
        User user = new User();
        //RestClient.Post("", user);

        
        string json = JsonUtility.ToJson(user);

        reference.Child("User").Child(user.UserName).SetRawJsonValueAsync(json).ContinueWith(task => {

            if (task.IsCompleted)
            {
                Debug.Log(json);
            }

        });


    }*/

}
