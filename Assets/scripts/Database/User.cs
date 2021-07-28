using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class User : MonoBehaviour
{
    public string UserName;
    public int UserScore;
    public string TeamName;
    public string TeamMateName;
    public int BallLocation;

    public User()
    {
        UserName = DatabaseTest.playerName;
        UserScore = DatabaseTest.playerScore;
        TeamName = DatabaseTest.teamName;
        TeamMateName = DatabaseTest.teamMate;
        BallLocation = DatabaseTest.ballLocation;

    }
}
