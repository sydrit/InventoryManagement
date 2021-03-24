using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class WinZone : MonoBehaviour
{
    int inWinZoneCount = 0;
    int highestWinZoneCount = 0;
    public int winCount;// = 30; //6
    public Text currentCountText;
    public Text highestCountText;
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inWinZoneCount >= winCount) {
            //you win!
            GetComponentInChildren<SpriteRenderer>().color = Color.green;
        }
        if (timer.GetTimeLeft() <=0) {
            GetComponentInChildren<SpriteRenderer>().color = Color.red;

        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //.Log("collision enter 2d" + collision.gameObject.name);
        if (collision.gameObject.GetComponent<FlockAgent>() != null)
        {
           // collision.gameObject.GetComponent<Flyer>().Stun();

            inWinZoneCount++;
            UpdateText();
           // Debug.Log("collision enter: " + inWinZoneCount);
        }

    }

    private void UpdateText()
    {
        currentCountText.text = "Current Trapped: " + inWinZoneCount;
        highestCountText.text = "Highest Trapped: " + highestWinZoneCount; 

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<FlockAgent>()!=null) {

            inWinZoneCount--;
            CheckHighScore();
            UpdateText();
//            Debug.Log("collision exit: " + inWinZoneCount);
        }
       

    }

    private void CheckHighScore()
    {
        if (inWinZoneCount > highestWinZoneCount) {
            highestWinZoneCount = inWinZoneCount;

        }


    }
}
