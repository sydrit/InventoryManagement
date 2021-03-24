using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Flyer : MonoBehaviour
{
    float speed = .05f;
    bool stunned = false; 
    // Start is called before the first frame update
    void Start()
    {
       CreateTriggers();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stunned)
        {
            transform.Translate(GetDirection() * speed);


        }

    }
    Vector3  GetDirection()
    {
        float x, y, z;
        float xSpeed = 0.6f; //wobble. 
        z = 0;
        y = Mathf.Sin(Time.fixedTime) * xSpeed;
        x = 1;
        Vector3 newPos = new Vector3(x,y,z);

        return newPos;
    }
    void CreateTriggers() {


        EventTrigger trigger = GetComponent<EventTrigger>();
        //on click
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnClickDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);

       

    }
     

    private void OnClickDelegate(PointerEventData data)
    {

        ChangeDirection();

    }

    public void ChangeDirection()
    {
        //Debug.Log("changing direction");

        //direction = direction * -1;
        //reversed = !reversed;
        float x = transform.position.x;
        float y = transform.position.y;

        double angle = Math.Atan(y / x);
        angle = angle * 180 / Mathf.PI;
        if ( x > 0) {
            angle -= 180;
        }

       // Debug.Log("Angle" + angle);
       // Debug.Log("position" + transform.position);

        transform.rotation = Quaternion.AngleAxis((float)angle, new Vector3(0, 0, 1));
        //transform.rotation = new Quaternion(0,0,1,Mathf.PI);
        //transform.RotateAroundLocal([0,0,1], .pi)


    }
    public void Stun() {

        StartCoroutine(StunCoroutine());

    }
    public IEnumerator StunCoroutine() {
        Debug.Log("stunned!");
        float duration = .5f;

      //  yield return new WaitForSeconds(delay);
        stunned = true;

        yield return new WaitForSeconds(duration);
        stunned = false;


    }
}
