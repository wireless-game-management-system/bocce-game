using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using Newtonsoft.Json.Linq;


public class DatabaseTest : MonoBehaviour
{
    
    public Text scoreText;
    public InputField nameText;
    public Text teamNameText;
    public InputField teamText;
    public InputField teamMateText;
    public InputField ballLocationText;
    public Text showData;

    private System.Random random = new System.Random();

    User user = new User();

    public static int playerScore;
    public static string playerName;
    public static string teamName;
    public static string teamMate;
    public static int ballLocation;



    // Start is called before the first frame update
    void Start()
    {
        User user = new User();
        playerScore = random.Next(0, 100);
        scoreText.text = "Your Score: " + playerScore;
        
    }

    public void onSubmit() 
    {
        playerName = nameText.text;
        teamName = teamText.text;
        teamMate = teamMateText.text;
        ballLocation = int.Parse(ballLocationText.text);

        PostToDatabase();
    }

    public void OnGet()
    {
        
        ReadFromDatabase();
        
    }
    
    
    private void PostToDatabase()

    {
        User user = new User();
        RestClient.Put("https://unity-game-767f2-default-rtdb.firebaseio.com/" +  playerName + ".json", user);
        
        
    }

    private void ReadFromDatabase()
    {
        
        playerName = nameText.text;
        RestClient.Get("https://unity-game-767f2-default-rtdb.firebaseio.com/" + playerName + ".json").Then(response =>
        {
            showData.text = response.Text;
            /*+ " " + response.Text.Substring(user.UserScore) + " " + response.Text.Substring(int.Parse(user.TeamName))
                + " " + response.Text.Substring(int.Parse(user.TeamMateName)) + " " + response.Text.Substring(user.BallLocation);*/
            
            /*
            string json = response.Text.Trim();
            showData.text = json;
            */



        });
    }

}
