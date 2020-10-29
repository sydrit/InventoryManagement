using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float laserSpeed = .2f;
    int direction;
    bool grow = true;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -.02f);
    }


    void Update()
    {
        if (grow) {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + laserSpeed, transform.localScale.z);
            //rotation determines axis of movement
            if (transform.localEulerAngles.z == 0) {
                transform.position = new Vector3(transform.position.x, transform.position.y + laserSpeed/2 * direction, transform.position.z);

            }
            else
                transform.position = new Vector3(transform.position.x + laserSpeed/2 * direction, transform.position.y , transform.position.z);

        }
        if (transform.localScale.y >= 20f) { //temp

            grow = false;

        }
        if (!grow) {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Laser>()!= null) {
            if (other.GetComponent<Laser>().grow == false)
            {
                grow = false;
                Debug.Log("laser hit another laser"); //works!
            }
            if (other.GetComponent<BallBounce>() != null) {
                grow = false;
                Debug.Log("laser hit ball");
                //lose a life
                // not triggering. because this is enter? and hmmmmm they both have rigid bodies. :( 

            }
        }
        
    }

    internal void setDirection(int v)
    {

        direction = v;
    }
}
