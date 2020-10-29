using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    private Rigidbody rb;
    public float thrust = 100.0f;
    Vector3 direction;

    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();
        //transform.position = new Vector3(0.0f, -2.0f, 0.0f);
        direction = transform.up;
        rb.AddForce(direction * thrust);

    }

    void FixedUpdate()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ball hit something");
        if (other.GetComponent<Laser>() != null) {
            Debug.Log("ball hit a laser");
            ChangeDirection();
            //stop the laser
        }
    }
    void ChangeDirection() { //this aint working well. they fall off the screen all the time real easy. Need to be stopped by the walls better.
        Vector3 incomingVelocity = rb.velocity;
        rb.velocity = new Vector3(Random.Range(0,1),Random.Range(0,1), Random.Range(0,1));
        //  rb.angularVelocity = new Vector3(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1));
        //thrust *= -1;
        rb.AddForce(incomingVelocity * -1
            + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0)*100);
    }
}
