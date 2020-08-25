using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
   static int w = 10;
   static int h = 10;
   GameObject[][] grid;
   public GameObject slotPrefab;
    int score = 0;
    GUIManager guiManager;

    //ok so we have a grid of game objects. now wat?
    // need to add an item to that grid. 

    // Start is called before the first frame update
    void Start()
    {
        guiManager = FindObjectOfType<GUIManager>();
        CreateGrid();
       
        DrawGrid();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateScore() {
        score = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j].GetComponent<Slot>().IsFilled()) {
                    score++;
                }
            }
        }
        guiManager.UpdateScoreText(score);   
    }
    public void PlaceItem(Item theItem, Vector3 newPos, Vector3 startingPos) {
        for (int i = 0; i < theItem.blocks.Length; i++)
        {
            for (int j = 0; j < theItem.blocks[i].Length; j++)
            {
                if (theItem.blocks[i][j] != null)
                {
                    //need some kind of check for when illegal move from start
                    if (newPos.x < w && newPos.y < h) {  //if within bounds....yuck i'm doing this check multiple places kinda
                        grid[(int)newPos.x + i][(int)newPos.y + j].GetComponent<Slot>().SetFilled(true);
                        theItem.OnGrid = true;
                    }


                }

                

            }
        }
        UpdateScore();
        
    }
    public void RemoveItem(Item theItem, Vector3 startingPos) {
        for (int i = 0; i < theItem.blocks.Length; i++)
        {
            for (int j = 0; j < theItem.blocks[i].Length; j++)
            {
               

                if (startingPos.x <= w && startingPos.y <= h)
                {

                    grid[(int)startingPos.x + i][(int)startingPos.y + j].GetComponent<Slot>().SetFilled(false);

                }

            }
        }
    }
    public bool IsLegal(Vector3 position, Item theItem) {
        // need to check every block, not just the item itself
        int x = (int)position.x;
        int y = (int)position.y;

       // Debug.Log("checking legal: " + x + "," + y);

        for (int i = 0; i < theItem.blocks.Length; i++)
        {
            for (int j = 0; j < theItem.blocks[i].Length; j++)
            {
                if (x + i >= w || y + j >= h || y + j < 0 || x + i < 0)
                {
                    return false;
                }
                if (grid[x+i][y+j].GetComponent<Slot>().IsFilled()) {

                    return false;

                }
                
            }
        }
        return true;
        /*
                if (x >= w || y >= h || y<0 || x<0)
        {
            return false;
        }
        if (!grid[x][y].GetComponent<Slot>().IsFilled())
        {  
            return true;
        }
        else
            return false;

        */
                

    }
    void CreateGrid() {

        grid = new GameObject[w][];
        for (int i =0; i < w; i++) {
            grid[i] = new GameObject[h];
        }



    }
    void DrawGrid() {

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {


               // Debug.Log("drawing grid" + i + "," + j);
                GameObject slotObj = Instantiate(slotPrefab);
                //imageObj.transform.localScale *= 8;
                //imageObj.AddComponent<SpriteRenderer>().sprite = theSprite; // chaining again, is this ok?

                slotObj.transform.SetParent(gameObject.transform); //this object's transform. someone else should create the items
                slotObj.transform.position = new Vector3(i, j, 0);



                grid[i][j] = slotObj;



            }
        }

    }
}
