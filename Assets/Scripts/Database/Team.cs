using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{

    public string teamName;
    public string teamName2;
    public string player_name;
    public string player_name2;
    public string score;
    /*
    public int ballPositionA;
    public int ballPositionB;
    */
    public Team()
    {
        teamName = scree_4.teamA;
        teamName2 = scree_4.teamB;
        player_name = scree_4.player1;
        player_name2 = scree_4.player2;
        score = scree_4.totalScore.ToString();
        /*
        ballPositionA = scree_4.ballP;
        ballPositionB = scree_4.ballP2;
        */
    }
}
