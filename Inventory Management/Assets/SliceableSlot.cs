using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceableSlot : MonoBehaviour
{
    public bool isEmpty = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Laser>()!=null) {
            isEmpty = true;
            GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("slot hit!");
        }

       
    }
}
