using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timerText;
    public float timeLeft = 100;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(timeLeft * 10) / 10;
        }
       
    }

    public float GetTimeLeft()
    {
        return timeLeft;
    }
}
