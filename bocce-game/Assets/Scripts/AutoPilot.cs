using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AutoPilot : MonoBehaviour
{
    public Rigidbody rd;
    public float moveSpeed = 10f;
    public int counter;
    public Text redTeamName1, redTeamName2, redTeamName3, redTeamName4;
    public Text blueTeamName1, blueTeamName2, blueTeamName3, blueTeamName4;

    //public GameObject redBall1, redBall2, redBall3, redBall4;
    //public GameObject blueBall1, blueBall2, blueBall3, blueBall4;

    private float xInput;
    private float yInput;
    private float zInput;

    private float maxValueX = 4.23f;
    private float minValueX = -3.06f;
    private float minValueZ = -13.51f;
    private float maxValueZ = -4.51f;
    public int firstTurnValue;
    public Boolean firstTurnedPlayed = false;
    public int gameCounter = 1;
    public Rigidbody bocceball;

    int team = 2; //0=red, 1=blue
    public int previousValue; //who played previously
    public int currentPlay; //who is currently playing

    void Start()
    {

        string redTeamPlayer = PlayerPrefs.GetString("redTeamPlayers");
        string blueTeamPlayer =  PlayerPrefs.GetString("blueTeamPlayers");

        char separator = ',';
        String[] redTeamPlayerList = redTeamPlayer.Split(separator);
        String[] blueTeamPlayerList = blueTeamPlayer.Split(separator);

        displayName(redTeamPlayerList, blueTeamPlayerList);



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !firstTurnedPlayed)
        {
            firstTurn();
            if (firstTurnValue == 0)
            {
                Rigidbody redBall = (Rigidbody)Instantiate(bocceball, new Vector3(2.689309f, 5.514f, 10.67379f), Quaternion.identity);
                redBall.GetComponent<Renderer>().material.color = GetColorBall(firstTurnValue);
                RandomCoordinates();
                redBall.transform.position = transform.position + new Vector3(xInput, yInput, zInput);
                previousValue = 0;
                gameCounter++;
                firstTurnedPlayed = true;
            }
            if (firstTurnValue == 1)
            {
                Rigidbody blueBall = (Rigidbody)Instantiate(bocceball, new Vector3(2.689309f, 5.514f, 10.67379f), Quaternion.identity);
                blueBall.GetComponent<Renderer>().material.color = GetColorBall(firstTurnValue);
                RandomCoordinates();
                blueBall.transform.position = transform.position + new Vector3(xInput, yInput, zInput);
                previousValue = 1;
                gameCounter++;
                firstTurnedPlayed = true;
            }
            
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && gameCounter > 7)
        {
            SceneManager.LoadScene(sceneBuildIndex: 2);
        }

            if (Input.GetKeyDown(KeyCode.Space))
        {
            if(previousValue == 0) 
            {
                Rigidbody blueBall = (Rigidbody)Instantiate(bocceball, new Vector3(2.689309f, 5.514f, 10.67379f), Quaternion.identity);
                blueBall.GetComponent<Renderer>().material.color = GetColorBall(1);
                RandomCoordinates();
                blueBall.transform.position = transform.position + new Vector3(xInput, yInput, zInput);
                previousValue = 1;
                gameCounter++;
            }
            else if(previousValue == 1)
            {
                Rigidbody redBall = (Rigidbody)Instantiate(bocceball, new Vector3(2.689309f, 5.514f, 10.67379f), Quaternion.identity);
                redBall.GetComponent<Renderer>().material.color = GetColorBall(0);
                RandomCoordinates();
                redBall.transform.position = transform.position + new Vector3(xInput, yInput, zInput);
                previousValue = 0;
                gameCounter++;
            }
        }


    }

    void displayName(string [] redTeamPlayerList, string [] blueTeamPlayerList) {
        counter = PlayerPrefs.GetInt("totalPlayer");
        switch (counter)
        {
            case 2:
                redTeamName1.text = redTeamPlayerList[0];
                blueTeamName1.text = blueTeamPlayerList[0];
                break;

            case 4:
                redTeamName1.text = redTeamPlayerList[0];
                blueTeamName1.text = blueTeamPlayerList[0];
                redTeamName2.text = redTeamPlayerList[1];
                blueTeamName2.text = blueTeamPlayerList[1];
                break;

            case 8:
                redTeamName1.text = redTeamPlayerList[0];
                blueTeamName1.text = blueTeamPlayerList[0];
                redTeamName2.text = redTeamPlayerList[1];
                blueTeamName2.text = blueTeamPlayerList[1];
                redTeamName3.text = redTeamPlayerList[2];
                blueTeamName3.text = blueTeamPlayerList[2];
                redTeamName4.text = redTeamPlayerList[3];
                blueTeamName4.text = blueTeamPlayerList[3];
                break;

            default:

                break;

        }
    }

    private void RandomCoordinates() {
        xInput = UnityEngine.Random.Range(minValueX, maxValueX);
        zInput = UnityEngine.Random.Range(minValueZ, maxValueZ);
        yInput = 5.514f;
    }

    private void firstTurn() {
        System.Random random = new System.Random();
        firstTurnValue = random.Next(0, 2);
    }

    Color GetColorBall(int team)
    {
        if(team == 0)
        {
            return Color.red;
        }
        else if (team == 1)
        {
            return Color.blue;
        }
        else
            return Color.white;
    }
}
