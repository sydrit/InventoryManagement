using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //.Log("collision enter 2d" + collision.gameObject.name);
    //    if (collision.gameObject.GetComponent<FlockAgent>() != null)
    //    {
    //        collision.gameObject.GetComponent<FlockAgent>().Stun();

           
    //    }



    //}
    private void OnCollisionExit2D(Collision2D collision)
    {
        FlockAgent agent = collision.gameObject.GetComponent<FlockAgent>();
        //.Log("collision enter 2d" + collision.gameObject.name);
        if (agent != null)
        {

            if (agent.IsScared()) {
                agent.Stun();
            }


        }
    }
}
