using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;


public class DatabaseTest : MonoBehaviour
{

    public Text scoreText;
    public InputField nameText;

    private System.Random random = new System.Random();

    public static int playerScore;
    public static string playerName;


    // Start is called before the first frame update
    void Start()
    {
        playerScore = random.Next(0, 100);
        scoreText.text = "Score: " + playerScore;
    }

    public void onSubmit() 
    {
        playerName = nameText.text;
        PostToDatabase();
    }

    private void PostToDatabase()

    {
        User user = new User();
        RestClient.Put("https://bocce-game-default-rtdb.firebaseio.com/.json", user);
    }

}
