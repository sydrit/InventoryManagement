using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    float maxX = 5f;
    float maxY = 3f;
    float minX = -5f;
    float minY = -3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public bool InBounds(Vector3 pos) {
        if (pos.x < maxX && pos.x > minX
            && pos.y < maxY && pos.y > minY)
        {
            return true;
        }
        else
            return false;

    }
}
