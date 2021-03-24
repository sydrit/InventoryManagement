using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    bool filled;
    string type;
    // Start is called before the first frame update
    void Start()
    {
        filled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetFilled(bool _filled) {
        filled = _filled;
    }
   public bool IsFilled() {

        return filled;
    }
}
