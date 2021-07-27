using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class User : MonoBehaviour
{
    public string userName;
    public int userScore;
    public string teamName;
    public string teamMateName;
    public int ballLocation;

    public User()
    {
        userName = DatabaseTest.playerName;
        userScore = DatabaseTest.playerScore;
        teamName = DatabaseTest.teamName;
        teamMateName = DatabaseTest.teamMate;
        ballLocation = DatabaseTest.ballLocation;

    }
}
