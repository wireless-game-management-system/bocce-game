using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class scree_4 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text Text;
     [SerializeField]
    private Text winning;
     [SerializeField]
    private Text looser;
     [SerializeField]
    private Text finalscore;
     [SerializeField]
    private Text matchwinner;

    

    void Start()
    {
        Text.text= PlayerPrefs.GetString("gamecount");
    string [] team= new string[2] {PlayerPrefs.GetString("team1"),PlayerPrefs.GetString("team2")};

        winning.text = team[Int32.Parse(PlayerPrefs.GetString("winningteam"))];
        looser.text= team[Int32.Parse(PlayerPrefs.GetString("losingteam"))];
        matchwinner.text=team[Int32.Parse(PlayerPrefs.GetString("winningteam"))];

    }

    // Update is called once per frame
    void Update()
    {

       
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {  
            SceneManager.LoadScene("Bocce"); 
         }
              if (Input.GetKeyDown(KeyCode.RightArrow)) {  
            SceneManager.LoadScene("screen5"); 
         }
        
    }
}
