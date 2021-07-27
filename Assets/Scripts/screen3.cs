using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using UnityEngine.SceneManagement;

public class screen3 : MonoBehaviour
{

   [SerializeField]
    private InputField input1;
     [SerializeField]
    private InputField input2;
     [SerializeField]
    private InputField input3;
     [SerializeField]
    private InputField input4;
     [SerializeField]
    private InputField input5;
     [SerializeField]
    private InputField input6;
     [SerializeField]
    private InputField input7;
     [SerializeField]
    private InputField input8;
     [SerializeField]
    private Text Team1;
     [SerializeField]
    private Text Team2;

    // Start is called before the first frame update
    void Start()
    {
         Team1.text=PlayerPrefs.GetString("team1");
        Team2.text=PlayerPrefs.GetString("team2");
    }

    // Update is called once per frame
    void Update()
    {

      
        PlayerPrefs.SetString("player1_team1", input1.text);
         PlayerPrefs.SetString("player2_team1", input2.text);
          PlayerPrefs.SetString("player3_team1", input3.text);
           PlayerPrefs.SetString("player4_team1", input4.text);
           PlayerPrefs.SetString("player1_team2", input5.text);
            PlayerPrefs.SetString("player2_team2", input6.text);
             PlayerPrefs.SetString("player3_team2", input7.text);
              PlayerPrefs.SetString("player4_team2", input8.text);
          if (Input.GetKeyDown(KeyCode.LeftArrow)) {  
            SceneManager.LoadScene("screen2"); 
    }
          if (Input.GetKeyDown(KeyCode.RightArrow)) {  
            SceneManager.LoadScene("Bocce"); 
    }
    }
}
