using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("p")) {
        //    Debug.Log("screengrab~ " + Application.dataPath);
        //    ScreenCapture.CaptureScreenshot("testing");
       // }
    }
    public void UpdateScoreText(int score) {
        scoreText.text = "Score: " + score;
    }
    public void DisplayGameOverText() {
        gameOverText.gameObject.SetActive(true);
    
    }
    
}
