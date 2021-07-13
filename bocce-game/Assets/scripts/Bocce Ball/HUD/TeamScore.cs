using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class TeamScore : MonoBehaviour
{
    public void SetColor(Color color)
    {
        GetComponent<Text>().color = color;
    }

    public void SetScore(int score)
    {
        GetComponent<Text>().text = score.ToString();
    }
}
