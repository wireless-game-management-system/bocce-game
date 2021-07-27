using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;


public class DatabaseTest : MonoBehaviour
{

    public Text scoreText;
    public InputField nameText;
    public Text teamNameText;
    public InputField teamText;
    public InputField teamMateText;
    public InputField ballLocationText;

    private System.Random random = new System.Random();

    public static int playerScore;
    public static string playerName;
    public static string teamName;
    public static string teamMate;
    public static int ballLocation;



    // Start is called before the first frame update
    void Start()
    {
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

    private void PostToDatabase()

    {
        User user = new User();
        RestClient.Post("https://unity-game-767f2-default-rtdb.firebaseio.com/.json", user);
        
        
    }

}
