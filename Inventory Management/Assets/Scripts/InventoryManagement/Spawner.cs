using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GUIManager guiManager;
    public GameObject itemPrefab;
    List<GameObject> items;
    int loseCount = 5;
    bool keepSpawning = true;
    // Start is called before the first frame update
    void Start()
    {
        guiManager = FindObjectOfType<GUIManager>();
        items = new List<GameObject>();
        InvokeRepeating("SpawnItem",0f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnItem() {
        if (keepSpawning) {
            items.Add(Instantiate(itemPrefab, new Vector3(12.5f, 5f, 0f), itemPrefab.transform.localRotation));
            CheckLose();
        }
       

    }
    public void CheckLose() {
        int queueCount = 0;
        for (int i =0; i < items.Count; i++) {
            if (!items[i].GetComponent<Item>().OnGrid) {
                queueCount++;
            }
        }
        Debug.Log("queuecount: " + queueCount);
        if (queueCount >= loseCount) {
            GameOver();
        }
    
    }
    public void GameOver() {
        keepSpawning = false;
        guiManager.DisplayGameOverText();
        Debug.Log("game over");
    
    }
}



