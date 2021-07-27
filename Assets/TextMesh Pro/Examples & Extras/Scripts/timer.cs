using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class timer : MonoBehaviour
{
    public float timelimit;
    public Text text_timer;
    [SerializeField]
    private Text Text1;
     [SerializeField]
    private Text Text2;
     [SerializeField]
    private Text Text3;
     [SerializeField]
    private Text Text4;
     [SerializeField]
    private Text Text5;
    [SerializeField]
    private Text Text6;
     [SerializeField]
    private Text Text7;
     [SerializeField]
    private Text Text8;
     [SerializeField]
    private Text Text9;
     [SerializeField]
    private Text Text10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.LeftArrow)) {  
            SceneManager.LoadScene("screen4"); 
         }
              if (Input.GetKeyDown(KeyCode.RightArrow)) {  
            SceneManager.LoadScene("screen6"); 
         }
        Text1.text=PlayerPrefs.GetString("team1");
        Text2.text=PlayerPrefs.GetString("team1");
        Text7.text=PlayerPrefs.GetString("player1_team1");
        Text6.text=PlayerPrefs.GetString("player1_team2");
        Text5.text=PlayerPrefs.GetString("team2score");
        Text10.text=PlayerPrefs.GetString("team1score");
        timelimit += Time.deltaTime;
        text_timer.text = " Time: " + Mathf.Round(timelimit);
    }
}
