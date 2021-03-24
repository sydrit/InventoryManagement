using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    static int w = 35;
    static int h = 35;
    private float offset;
    GameObject[][] grid;
    public GameObject slotPrefab;
    public GameObject laserPrefab;


    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
        DrawGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateGrid()
    {

        grid = new GameObject[w][];
        for (int i = 0; i < w; i++)
        {
            grid[i] = new GameObject[h];
        }



    }
    void CheckForCompletedEdges() {
        //go along and see where stuff is empty.
        // need to actually make the grid empty when we delete the objects
        for (int i = 0; i < grid.Length; i++)
        {

            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j].GetComponent<SliceableSlot>().isEmpty) {
                    //if we find an empty one... look along the x axis to find the wall??? fk. 
                }
            }
        }
    }
    void DrawGrid()
    {
      //  float offset = .25f;
        for (int i = 0; i < grid.Length; i++)
        {

            for (int j = 0; j < grid[i].Length; j++)
            {

                // Debug.Log("drawing grid" + i + "," + j);
                GameObject slotObj = Instantiate(slotPrefab);
                offset = slotObj.transform.localScale.x;

                //imageObj.transform.localScale *= 8;
                //imageObj.AddComponent<SpriteRenderer>().sprite = theSprite; // chaining again, is this ok?

                slotObj.transform.SetParent(gameObject.transform); //this object's transform. someone else should create the items
                slotObj.transform.position = new Vector3(offset * i, offset * j, 0);



                grid[i][j] = slotObj;

                //offsetY += .25f;


            }
            //offsetX += .25f;

        }
        FireBorderLasers();
    }

    private void FireBorderLasers() //not quite right
    {

        GameObject laser = Instantiate(laserPrefab);
        laser.transform.position = new Vector3(0,0,0);

        GameObject laser2 = Instantiate(laserPrefab);
        laser2.transform.position = new Vector3(0, grid[0].Length * offset, 0);
        laser2.transform.localEulerAngles = new Vector3(0, 0, 90);


        GameObject laser3 = Instantiate(laserPrefab);
        laser3.transform.position = new Vector3(grid.Length * offset, 0, 0);
        laser3.transform.localEulerAngles = new Vector3(0, 0, 90);

        GameObject laser4 = Instantiate(laserPrefab);
        laser4.transform.position = new Vector3(grid.Length * offset, grid[0].Length * offset, 0);




    }
}
