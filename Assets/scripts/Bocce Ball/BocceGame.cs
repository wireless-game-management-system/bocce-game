using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class BocceGame : MonoBehaviour
{
    enum GameMode
    {
        Pause = 0,
        Setup = 1,
        Aiming = 2,
        AimingFinish = 3,
        RoundResult = 4,
        GameResult = 5,
    }
    int gamecount = 0;
    static GameMode gameMode;
    static GameMode prevGameMode;

    // cameras
    public Camera MainCamera;
    public Camera PlayerCamera;

    public Image redBall1;
    public Image redBall2;
    public Image redBall3;
    public Image redBall4;

    public Image blueBall1;
    public Image blueBall2;
    public Image blueBall3;
    public Image blueBall4;

    public Text blueName1;
    public Text blueName2;
    public Text blueName3;
    public Text blueName4;

    public Text redName1;
    public Text redName2;
    public Text redName3;
    public Text redName4;

    public Text blueScore1;
    public Text blueScore2;
    public Text blueScore3;
    public Text blueScore4;

    public Text redScore1;
    public Text redScore2;
    public Text redScore3;
    public Text redScore4;

    private int redCount = 0;
    private int blueCount = 0;

    //private string[] blueTeamMemberName = { PlayerPrefs.GetString("player1_team1"), PlayerPrefs.GetString("player2_team1"), PlayerPrefs.GetString("player3_team1"), PlayerPrefs.GetString("player4_team1")};
    //private string[] redTeamMemberName = { PlayerPrefs.GetString("player1_team2"), PlayerPrefs.GetString("player2_team2"), PlayerPrefs.GetString("player3_team2"), PlayerPrefs.GetString("player4_team2") };
    
    // game variables
    const int NumTeams = 2;
    const float MaxBallForce = 1000f;
    public Rigidbody BocceBallPrefab;
    
    Rigidbody jack = null;
    Rigidbody currentBall = null;
    private int firstCounter = 0; //for pallino
    private bool jackThrowLegal=true;
    private bool isJackInGame = false;
    private int gameCount = 0;
    // GUI
    bool forceIncreasing = true;    
    public Slider BallForceBar;
    public float ForceIncrement = 0.01f;
    
    int[] teamScore = new int[NumTeams];
    public Text[] TeamScoreText = new Text[NumTeams];
    public Text MessageText;
    public Text HintMessageText;
    

    float currentWaitTime = 0.0f;
    const float minWaitBetweenThrows = 1.0f; // seconds
    
    public int BallsPerTeam = 4;
    public int WinningScore = 7;
    
    int currentTeam; // which team's turn it is
    int[] teamBalls = new int[NumTeams];
    List<float>[] teamBallDistanceSq = new List<float>[NumTeams];
    
    // menu
    public static bool Paused { get { return gameMode == GameMode.GameResult; } }

    void Start()
    {

         string[] blueTeamMemberName = { PlayerPrefs.GetString("player1_team1"), PlayerPrefs.GetString("player2_team1"), PlayerPrefs.GetString("player3_team1"), PlayerPrefs.GetString("player4_team1")};
     string[] redTeamMemberName = { PlayerPrefs.GetString("player1_team2"), PlayerPrefs.GetString("player2_team2"), PlayerPrefs.GetString("player3_team2"), PlayerPrefs.GetString("player4_team2") };
        for (int i = 0; i < NumTeams; ++i)

        { 
            teamBallDistanceSq [i] = new List<float>();
            SetTeamScore(i, 0);
        }
    
        SetGameMode(GameMode.Setup);

        redName1.GetComponent<Text>().text = redTeamMemberName[0];
        redName2.GetComponent<Text>().text = redTeamMemberName[1];
        redName3.GetComponent<Text>().text = redTeamMemberName[2];
        redName4.GetComponent<Text>().text = redTeamMemberName[3];

        blueName1.GetComponent<Text>().text = blueTeamMemberName[0];
        blueName2.GetComponent<Text>().text = blueTeamMemberName[1];
        blueName3.GetComponent<Text>().text = blueTeamMemberName[2];
        blueName4.GetComponent<Text>().text = blueTeamMemberName[3];
    }
    
    #region Pause
    
    void TogglePause()
    {
        Pause(!Paused);
    }
    
    void Pause()
    {
        Pause(true);
    }

    void setPositionText(Text textPosition, Vector3 currentBall) 
    {
        textPosition.GetComponent<Text>().text = currentBall.ToString();
    }
    
    void Pause(bool pause)
    {
        if (gameMode == GameMode.Pause)
        {
            gameMode = prevGameMode;
            
            Time.timeScale = 1.0f;
        } else
        {
            prevGameMode = gameMode;
            gameMode = GameMode.Pause;
            
            Time.timeScale = 0.0f;
        }

        if (Paused)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = (gameMode == GameMode.Aiming) ? CursorLockMode.Locked : CursorLockMode.None;
    }
    
    #endregion
	
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.LeftArrow)) {  
            SceneManager.LoadScene("screen3"); 
         }
            
            
                 if (Input.GetKeyDown(KeyCode.RightArrow)) {  
            SceneManager.LoadScene("screen4"); 
            
    }
        // pausing
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
        
        if (!Paused)
        {
            switch (gameMode)
            {
                case GameMode.Setup:
                    {
                        
                        
                        //currentBall = jack = CreateBall();
                        //currentBall.transform.localScale *= 0.7f; // jack is smaller
                    
                        // random direction and force for the JACK
                        //Quaternion xQuaternion = Quaternion.AngleAxis(Random.Range(-20, 20), Vector3.up);
                        //Quaternion yQuaternion = Quaternion.AngleAxis(Random.Range(0, 15), -Vector3.right);

                        //Quaternion originalRotation = transform.localRotation;
                        //  PlayerCamera.gameObject.transform.localRotation = originalRotation * xQuaternion * yQuaternion;

                        //BallForceBar.value = Random.Range(0.5f, 0.89f);

                        //ThrowBall(PlayerCamera.gameObject.transform.forward * (MaxBallForce * BallForceBar.value));

                        // SetGameMode(GameMode.Aiming);
                        // break;
                        SetGameMode(GameMode.Aiming);
                        break;
                    }
                case GameMode.Aiming:
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {  
                            if(firstCounter == 0 || !jackThrowLegal)
                            {
                                currentBall = jack = CreateBall();
                                currentBall.transform.localScale *= 0.7f; // jack is smaller
                                ThrowBall(PlayerCamera.gameObject.transform.forward * (MaxBallForce * BallForceBar.value));
                                SetGameMode(GameMode.AimingFinish);
                                firstCounter++;
                                jackThrowLegal = true;
                                break;
                            }


                            currentBall = CreateBall(currentTeam);
                            teamBalls [currentTeam] -= 1;


                            if (currentTeam == 0)
                            {
                                if (teamBalls[currentTeam] == 3)
                                {
                                    blueBall1.enabled = false;

                                }
                                else if (teamBalls[currentTeam] == 2)
                                {
                                    blueBall2.enabled = false;
                                }
                                else if (teamBalls[currentTeam] == 1)
                                {
                                    blueBall3.enabled = false;
                                }
                                else if (teamBalls[currentTeam] == 0)
                                {
                                    blueBall4.enabled = false;
                                }
                            }

                            if (currentTeam == 1)
                            {
                                if (teamBalls[currentTeam] == 3)
                                {
                                    redBall1.enabled = false;
                                }
                                else if (teamBalls[currentTeam] == 2)
                                {
                                    redBall2.enabled = false;
                                }
                                else if (teamBalls[currentTeam] == 1)
                                {
                                    redBall3.enabled = false;
                                }
                                else if (teamBalls[currentTeam] == 0)
                                {
                                    redBall4.enabled = false;
                                }
                            }


                            ThrowBall(PlayerCamera.gameObject.transform.forward * (MaxBallForce * BallForceBar.value));
                        
                            SetGameMode(GameMode.AimingFinish);
                        } else
                        {
                            if (forceIncreasing)
                            {
                                BallForceBar.value += ForceIncrement;
                                if (BallForceBar.value >= 1.0f)
                                {
                                    BallForceBar.value = 1.0f;
                                    forceIncreasing = false;
                                }
                            } else
                            {
                                BallForceBar.value -= ForceIncrement;
                                if (BallForceBar.value <= 0.0f)
                                {
                                    BallForceBar.value = 0.0f;
                                    forceIncreasing = true;
                                }
                            }
                        }
                    
                        break;
                    }
                case GameMode.AimingFinish:
                    {




                        if (currentWaitTime <= 0.0f)
                        {
                            if (!AreBallsMoving())
                            {
                                if (currentTeam == 0)
                                {
                                    if (teamBalls[currentTeam] == 3)
                                    {
                                        setPositionText(blueScore1, currentBall.GetComponent<BocceBall>().transform.position);
                                    }
                                    if (teamBalls[currentTeam] == 2)
                                    {
                                        setPositionText(blueScore2, currentBall.GetComponent<BocceBall>().transform.position);
                                    }
                                    if (teamBalls[currentTeam] == 1)
                                    {
                                        setPositionText(blueScore3, currentBall.GetComponent<BocceBall>().transform.position);
                                    }
                                    if (teamBalls[currentTeam] == 0)
                                    {
                                        setPositionText(blueScore4, currentBall.GetComponent<BocceBall>().transform.position);
                                    }
                                }

                                if (currentTeam == 1)
                                {
                                    if (teamBalls[currentTeam] == 3)
                                    {
                                        setPositionText(redScore1, currentBall.GetComponent<BocceBall>().transform.position);
                                    }
                                    if (teamBalls[currentTeam] == 2)
                                    {
                                        setPositionText(redScore2, currentBall.GetComponent<BocceBall>().transform.position);
                                    }
                                    if (teamBalls[currentTeam] == 1)
                                    {
                                        setPositionText(redScore3, currentBall.GetComponent<BocceBall>().transform.position);
                                    }
                                    if (teamBalls[currentTeam] == 0)
                                    {
                                        setPositionText(redScore4, currentBall.GetComponent<BocceBall>().transform.position);
                                    }
                                }

                                if (prevGameMode != GameMode.Setup)
                                {
                                    int closestTeam = GetClosestTeam();
                                    currentTeam = (closestTeam == 0 ? 1 : 0);
                                    // if the team is out of balls let the other finish
                                    if (teamBalls [currentTeam] == 0)
                                        currentTeam = (currentTeam == 0 ? 1 : 0);
                                }
                                
                                BocceBall jackComponent = jack.GetComponent<BocceBall>();
                                if (jackComponent && !jackComponent.InBounds && !isJackInGame)
                                {
                                    Invoke("displayMessage", 0.5f);
                                    // jack is out of bounds
                                    jackThrowLegal = false;
                                    SetGameMode(GameMode.Setup);
                                }

                                else
                                {
                                    SetGameMode(teamBalls.Sum() > 0 ? GameMode.Aiming : GameMode.RoundResult);
                                    isJackInGame = true;
                                }
                            }
                        } else
                            currentWaitTime -= Time.deltaTime;
                        break;
                    }
                case GameMode.RoundResult:
                    {

                        blueBall1.enabled = true;
                        blueBall2.enabled = true;
                        blueBall3.enabled = true;
                        blueBall4.enabled = true;

                        redBall1.enabled = true;
                        redBall2.enabled = true;
                        redBall3.enabled = true;
                        redBall4.enabled = true;
                        jackThrowLegal = true;
                        firstCounter = 0;
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            if (teamScore.Max() >= WinningScore)
                                SetGameMode(GameMode.GameResult);
                            else
                                SetGameMode(GameMode.Setup);
                        }
                        break;
                    }                    
                case GameMode.GameResult:
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                            SceneManager.LoadScene(0);
                        break;
                    }
            }
        }
    }
    
    #region Events
    
    void OnApplicationFocus(bool focusStatus)
    {
        if (!Paused && !focusStatus)
            Pause();
    }

    #endregion

    void displayMessage()
    {
        SetHintMessageText("Invalid Throw!!");
    }

    bool AreBallsMoving()
    {
        IEnumerable<GameObject> gameObjects = GameObject.FindGameObjectsWithTag("BocceBall");
        bool inMotion = gameObjects.Count(ball => {
            BocceBall component = ball.GetComponent<BocceBall>();
            if (component && component.InBounds && component.IsMoving)
                return true;
            return false;
        }) > 0;
        
        return inMotion;
    }
    
    List<float> GetBallDistances(int team)
    {
        List<float> distances = new List<float>();
    
        IEnumerable<GameObject> gameObjects = GameObject.FindGameObjectsWithTag("BocceBall").Where(gameObject => {
            BocceBall component = gameObject.GetComponent<BocceBall>();
            return (component && component.Team == team && component.InBounds);
        });
        
        foreach (GameObject gameObject in gameObjects)
        {
            BocceBall component = gameObject.GetComponent<BocceBall>();
            if (component)
            {
                float distanceSq = component.GetDistanceSqToPoint(jack.transform.position);
                distances.Add(distanceSq);
            }
        }
        
        return distances;
    }
    
    int GetClosestTeam()
    {
        int team = currentTeam;
        
        float nearestDistanceSq = Mathf.Infinity;
        for (int i = 0; i < NumTeams; ++i)
        {
            List<float> distances = GetBallDistances(i);
            if (distances.Count() == 0)
                continue;
            
            float distanceSq = distances.Min();
            if (distanceSq < nearestDistanceSq)
            {
                nearestDistanceSq = distanceSq;
                team = i;
            }
        }
        
        return team;
    }
    
    Color GetTeamColor(int team)
    {
        if (team < 0 || team >= NumTeams)
            return Color.white;
        return TeamScoreText [team].GetComponent<Text>().color;
    }
    
    void SetTeamScore(int team, int score)
    {
        teamScore [team] = score;
        TeamScore component = TeamScoreText [team].GetComponent<TeamScore>();
        if (component)
            component.SetScore(score);
    }
    
    void SetGameMode(GameMode gameMode_)
    {
        Cursor.lockState = CursorLockMode.None;
        
        switch (gameMode_)
        {
            case GameMode.Setup:
                {
                    // random team goes first
                    currentTeam = 0;
                    for (int i = 0; i < NumTeams; ++i)
                        teamBalls [i] = BallsPerTeam;
                
                    // get rid of all the previous balls
                    IEnumerable<GameObject> gameObjects = GameObject.FindGameObjectsWithTag("BocceBall");
                    foreach (GameObject gameObject in gameObjects)
                        GameObject.Destroy(gameObject);
                    jack = null;
                
                    SetHintMessageText("Throwing the jack!");
                    break;
                }
            case GameMode.Aiming:
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    

                    if(currentTeam == 0)
                    {
                        if(blueCount == 0)
                        {
                            redName1.GetComponent<Text>().color = Color.white;
                            redName2.GetComponent<Text>().color = Color.white;
                            redName3.GetComponent<Text>().color = Color.white;
                            redName4.GetComponent<Text>().color = Color.white;

                            blueName1.GetComponent<Text>().color = Color.blue;
                            blueCount++;
                        }
                        else if (blueCount == 1)
                        {
                            redName1.GetComponent<Text>().color = Color.white;
                            redName2.GetComponent<Text>().color = Color.white;
                            redName3.GetComponent<Text>().color = Color.white;
                            redName4.GetComponent<Text>().color = Color.white;
                            blueName1.GetComponent<Text>().color = Color.white;


                            blueName2.GetComponent<Text>().color = Color.blue;
                            blueCount++;
                        }
                        else if (blueCount == 2)
                        {
                            redName1.GetComponent<Text>().color = Color.white;
                            redName2.GetComponent<Text>().color = Color.white;
                            redName3.GetComponent<Text>().color = Color.white;
                            redName4.GetComponent<Text>().color = Color.white;
                            blueName2.GetComponent<Text>().color = Color.white;

                            blueName3.GetComponent<Text>().color = Color.blue;
                            blueCount++;
                        }
                        else if (blueCount == 3)
                        {
                            redName1.GetComponent<Text>().color = Color.white;
                            redName2.GetComponent<Text>().color = Color.white;
                            redName3.GetComponent<Text>().color = Color.white;
                            redName4.GetComponent<Text>().color = Color.white;
                            blueName3.GetComponent<Text>().color = Color.white;

                            blueName4.GetComponent<Text>().color = Color.blue;
                            blueCount++;
                        }
                    }

                    else if (currentTeam == 1)
                    {
                        if (redCount == 0)
                        {
                            blueName1.GetComponent<Text>().color = Color.white;
                            blueName2.GetComponent<Text>().color = Color.white;
                            blueName3.GetComponent<Text>().color = Color.white;
                            blueName4.GetComponent<Text>().color = Color.white;

                            redName1.GetComponent<Text>().color = Color.red;
                            redCount++;
                        }
                        else if (redCount == 1)
                        {

                            blueName1.GetComponent<Text>().color = Color.white;
                            blueName2.GetComponent<Text>().color = Color.white;
                            blueName3.GetComponent<Text>().color = Color.white;
                            blueName4.GetComponent<Text>().color = Color.white;
                            redName1.GetComponent<Text>().color = Color.white;

                            redName2.GetComponent<Text>().color = Color.red;
                            redCount++;
                        }
                        else if (redCount == 2)
                        {
                            blueName1.GetComponent<Text>().color = Color.white;
                            blueName2.GetComponent<Text>().color = Color.white;
                            blueName3.GetComponent<Text>().color = Color.white;
                            blueName4.GetComponent<Text>().color = Color.white;
                            redName2.GetComponent<Text>().color = Color.white;

                            redName3.GetComponent<Text>().color = Color.red;
                            redCount++;
                        }
                        else if (redCount == 3)
                        {
                            blueName1.GetComponent<Text>().color = Color.white;
                            blueName2.GetComponent<Text>().color = Color.white;
                            blueName3.GetComponent<Text>().color = Color.white;
                            blueName4.GetComponent<Text>().color = Color.white;
                            redName3.GetComponent<Text>().color = Color.white;
                            redName4.GetComponent<Text>().color = Color.red;
                            redCount++;
                        }
                    }


                    SetMessageText("Team " + (currentTeam + 1) + "'s turn!", currentTeam);
                    SetHintMessageText("Press SPACE to throw ball.");
                    break;
                }
            case GameMode.AimingFinish:
                {
                    currentWaitTime = minWaitBetweenThrows;
                
                    SetMessageText("Waiting for balls to stop...");
                    SetHintMessageText("");
                    break;
                }
            case GameMode.RoundResult:
                {                
                    int winningTeam = GetClosestTeam();
                    int losingTeam = (winningTeam == 0 ? 1 : 0);
                   
                    List<float> winningDistances = GetBallDistances(winningTeam);
                    List<float> losingDistances = GetBallDistances(losingTeam);

                    int points;
                    if (losingDistances.Count() == 0) // how'd this player throw all their balls out of bounds?
                        points = winningDistances.Count();
                    else
                        points = winningDistances.Count(distanceSq => distanceSq < losingDistances.Min());
                    teamScore [winningTeam] += points;

                    SetTeamScore(winningTeam, teamScore [winningTeam]);
                    SetMessageText("Team " + (winningTeam + 1).ToString() + " scores " + points.ToString() + " points!");
                    
                    redCount = 0;
                    blueCount = 0;
                    isJackInGame = false;
                    blueName1.GetComponent<Text>().color = Color.white;
                    blueName2.GetComponent<Text>().color = Color.white;
                    blueName3.GetComponent<Text>().color = Color.white;
                    blueName4.GetComponent<Text>().color = Color.white;

                    redName1.GetComponent<Text>().color = Color.white;
                    redName2.GetComponent<Text>().color = Color.white;
                    redName3.GetComponent<Text>().color = Color.white;
                    redName4.GetComponent<Text>().color = Color.white;


                     PlayerPrefs.SetString("team1score",teamScore[losingTeam].ToString());
                     PlayerPrefs.SetString("team2score",teamScore[winningTeam].ToString());
                     PlayerPrefs.SetString("winningteam", winningTeam.ToString());
                     PlayerPrefs.SetString("losingteam", losingTeam.ToString());

                    gameCount++;
                    PlayerPrefs.SetString("gamecount", gameCount.ToString());
                    break;

                }
            case GameMode.GameResult:
                {
                    int winningTeam = 0;
                    int highScore = 0;
                    for (int i = 0; i < NumTeams; ++i)
                    {
                        if (teamScore [i] > highScore)
                        {
                            highScore = teamScore [i];
                            winningTeam = i;
                        }
                    }
                   
                    SetMessageText("Team " + (winningTeam + 1).ToString() + " wins!", winningTeam);
                    SetHintMessageText("Press SPACE to return to main menu.");
                    
                   
                    break;
                }
        }
        
        MainCamera.gameObject.SetActive(gameMode_ != GameMode.Aiming);
        PlayerCamera.gameObject.SetActive(gameMode_ == GameMode.Aiming);
        //BallForceBar.gameObject.SetActive(gameMode_ == GameMode.Aiming);
    
        prevGameMode = gameMode;
        gameMode = gameMode_;
    }
    
    #region SetMessageText
    
    void SetMessageText(string message_)
    {

        SetMessageText(message_, -1);
    }
    
    void SetMessageText(string message_, int team)
    {
        MessageText.GetComponent<Text>().text = message_;
        MessageText.GetComponent<Text>().color = GetTeamColor(team);
    }
    
    #endregion
    
    void SetHintMessageText(string message_)
    {
        HintMessageText.GetComponent<Text>().text = message_;
    }


    
    #region CreateBall
    
    Rigidbody CreateBall()
    {
        return CreateBall(-1);
    }
    
    Rigidbody CreateBall(int team_)
    {
        return CreateBall(team_, PlayerCamera.gameObject.transform.position);
    }
    
    Rigidbody CreateBall(int team_, Vector3 position_)
    {
        Rigidbody rigidBody = (Rigidbody)Instantiate(BocceBallPrefab, position_, new Quaternion());
        BocceBall component = rigidBody.GetComponent<BocceBall>();
        if (component)
            component.Team = team_;
        rigidBody.GetComponent<Renderer>().material.color = GetTeamColor(team_);            
        return rigidBody;
    }
    
    #endregion
    
    void ThrowBall(Vector3 force)
    {
        currentBall.AddForce(force);
    } 
}