using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorController : MonoBehaviour
{
    Vector3 mouseStartPos;
    Vector3 mouseEndPos;

    public GameObject Laser;

    float moveSpeed = 100f;


    private void Start()
    {

    }

    // on tap, move cursor to that location
    // on drag, point direction
    // on release, fire laser
    private float RoundTo(float input, float offset, float fraction) {

       float output = ((Mathf.Round((input - offset) * fraction)) / fraction) + offset;

        return output;

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //click
        {
            var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = transform.position.z;
            transform.position = targetPos;//Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

           
            float roundedX = RoundTo(targetPos.x, 2, .25f);
            float roundedY = RoundTo(targetPos.y, 2, .25f);
           

            targetPos = new Vector3(roundedX, roundedY, -1);

            mouseStartPos = targetPos;


        }
        if (Input.GetMouseButton(0))
        {
            var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseEndPos = targetPos;

            Vector3 distance = mouseEndPos - mouseStartPos;
            if (distance.y > 0 && Mathf.Abs(distance.y) > Mathf.Abs(distance.x))
            {
               // Debug.Log("Top");
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            else if (distance.y < 0 && Mathf.Abs(distance.y) > Mathf.Abs(distance.x))
            {
                //Debug.Log("Bot");
                transform.localEulerAngles = new Vector3(0, 0, 0);

            }
            else if (distance.x < 0 && Mathf.Abs(distance.y) < Mathf.Abs(distance.x))
            {
                //Debug.Log("Left");
                transform.localEulerAngles = new Vector3(0, 0, 90);

            }
            else if (distance.x > 0 && Mathf.Abs(distance.y) < Mathf.Abs(distance.x))
            {
               // Debug.Log("Right");
                transform.localEulerAngles = new Vector3(0, 0, 90);

            }

        }
        if (Input.GetMouseButtonUp(0)) { //released

            //fire laser
            FireLaser();
            //stop movement until this laser is done doing its thing.
        }
    }
    public void MoveCursor(Vector3 newPos)
    {
        
        transform.position = newPos;
           

    }
    public void FireLaser() {

      GameObject laser =  Instantiate(Laser, transform.position, transform.rotation); //create a laser class and do stuff in there. 
        laser.GetComponent<Laser>().setDirection(1);
        laser = Instantiate(Laser, transform.position, transform.rotation); //create a laser class and do stuff in there. 
        laser.GetComponent<Laser>().setDirection(-1);
        //need to set position a little bit offset. 

        // starting from this position, draw out towards sides
        //how are we doing this exactly? squares? draw a sprite and grow it maybe? 
        // if you hit something,
        // if its a bad guy, break
        // if its a wall, stop
        //fill in the space (grid should do that.
        //send it an event that says a new wall has been made? event that fire happened? that fire stopped?)


    }


}
