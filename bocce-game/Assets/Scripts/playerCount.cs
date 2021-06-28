using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerCount : MonoBehaviour
{

    public int counter;
    public Text playerCounter;
    public Text redTeamMemberList;
    public Text blueTeamMemberList;


    string[] namePlateOne = {"John", "Kate", "Mike", "Dan"};
    string[] namePlateTwo = { "Jay", "Richard", "AK", "Peter" };
    
    public void incrementCounter()
    {
        counter = counter + 2;
    }

    public void decrementCounter()
    {
        counter = counter - 2;
    }

    public void done() 
    {
        PlayerPrefs.SetInt("totalPlayer", counter);
        string redTeamPlayers = string.Join(",", namePlateOne, 0, (counter - 1));
        string blueTeamPlayers = string.Join(",", namePlateTwo, 0, (counter - 1));
        PlayerPrefs.SetString("redTeamPlayers", redTeamPlayers);
        PlayerPrefs.SetString("blueTeamPlayers", blueTeamPlayers);
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
    // Update is called once per frame
    void Update()
    {
        playerCounter.text = counter.ToString();

        displayName();
    }

    void displayName() {
        switch (counter)
        {
            case 2:
                redTeamMemberList.text = "1. " + namePlateOne[0];
                blueTeamMemberList.text = "1. " + namePlateTwo[0];
                break;

            case 4:
                redTeamMemberList.text = "1. " + namePlateOne[0] + "\n" + "2. " + namePlateOne[1];
                blueTeamMemberList.text = "1. " + namePlateTwo[0] + "\n" + "2. " + namePlateTwo[1];
                break;

            case 6:
                redTeamMemberList.text = "1. " + namePlateOne[0] + "\n" + "2. " + namePlateOne[1] + "\n" + "3. " + namePlateOne[2];
                blueTeamMemberList.text = "1. " + namePlateTwo[0] + "\n" + "2. " + namePlateTwo[1] + "\n" + "3. " + namePlateTwo[2];
                break;

            case 8:
                redTeamMemberList.text = "1. " + namePlateOne[0] + "\n" + "2. " + namePlateOne[1] + "\n" + "3. " + namePlateOne[2] + "\n" + "4. " + namePlateOne[3];
                blueTeamMemberList.text = "1. " + namePlateTwo[0] + "\n" + "2. " + namePlateTwo[1] + "\n" + "3. " + namePlateTwo[2] + "\n" + "4. " + namePlateTwo[3];
                break;

            default:

                break;

        }
    }
}
