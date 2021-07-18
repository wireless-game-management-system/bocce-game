using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class User : MonoBehaviour
{
    public string userName;
    public int userScore;

    public User()
    {
        userName = DatabaseTest.playerName;
        userScore = DatabaseTest.playerScore;
    }
}
