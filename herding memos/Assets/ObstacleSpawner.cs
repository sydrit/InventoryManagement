using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            spawnPosition.z = 0.0f;

            Instantiate(obstacle, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }


    
}
