using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float timelimit;
    public Text text_timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timelimit += Time.deltaTime;
        text_timer.text = " Time: " + Mathf.Round(timelimit);
    }
}
