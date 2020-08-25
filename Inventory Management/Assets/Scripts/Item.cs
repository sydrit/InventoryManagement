using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
   
   public GameObject[][] blocks;
    public GameObject blockPrefab;
    InventoryGrid inventoryGrid;
    Vector3 startingPos;
    ColorManager colorManager;

    private bool onGrid = false;

    // Start is called before the first frame update
    void Start()
    {
        inventoryGrid = FindObjectOfType<InventoryGrid>();
        colorManager = FindObjectOfType<ColorManager>();
        GenerateItem();

        CreateTriggers();
        
    }
    public bool OnGrid { get => this.onGrid; set => this.onGrid = value; }

    void CreateTriggers() {
        EventTrigger trigger = GetComponent<EventTrigger>();
        //on drag
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Drag;
        entry.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
        //on mouse up
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.EndDrag;
        entry.callback.AddListener((data) => { OnEndDragDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.BeginDrag;
        entry.callback.AddListener((data) => { OnBeginDragDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }
    public void OnBeginDragDelegate(PointerEventData data) {

        
        startingPos = transform.position;
    }
    public void OnEndDragDelegate(PointerEventData data) {
        //Create a ray going from the camera through the mouse position
        Ray ray = Camera.main.ScreenPointToRay(data.position);
        //Calculate the distance between the Camera and the GameObject, and go this distance along the ray
        Vector2 rayPoint = ray.GetPoint(Vector2.Distance(transform.position, Camera.main.transform.position));
        //Move the GameObject when you drag it
       // transform.position = new Vector3(rayPoint.x, rayPoint.y, -1);


        //find where you are in the world.
       // Debug.Log("mouse dragEnd at: " + rayPoint);
        float currentX = transform.position.x;
        float currentY = transform.position.y;
        float roundedX = Mathf.Round(currentX);
        float roundedY = Mathf.Round(currentY);
        Vector3 newPos = new Vector3(roundedX, roundedY, -1);

        MoveItem(newPos);
        

    }
    public void MoveItem(Vector3 newPos) {
        if (inventoryGrid.IsLegal(newPos, this))
        {
            transform.position = newPos;
            inventoryGrid.PlaceItem(this, newPos, startingPos);
        }
        else {
            transform.position = startingPos;
            inventoryGrid.PlaceItem(this, startingPos, startingPos);

        }

    }
    public void OnDragDelegate(PointerEventData data)
    {
        //Create a ray going from the camera through the mouse position
        Ray ray = Camera.main.ScreenPointToRay(data.position);
        //Calculate the distance between the Camera and the GameObject, and go this distance along the ray
        Vector2 rayPoint = ray.GetPoint(Vector2.Distance(transform.position, Camera.main.transform.position));
        //Move the GameObject when you drag it
        transform.position = new Vector3( rayPoint.x, rayPoint.y, -1);
        
        inventoryGrid.RemoveItem(this, startingPos);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateEmptyGrid() {
        int maxX = 4;
        int maxY = 4;
        int x = Random.Range(1, maxX);
       // Debug.Log("x " + x);

        blocks = new GameObject[x][];
        for (int i = 0; i < x; i++)
        {
            int y = Random.Range(0, maxY);
            //Debug.Log("y " + y);

            blocks[i] = new GameObject[y + 1];
            // need to assign a block there in each of these slots.

        }
    }
    void GenerateItem() {
        CreateEmptyGrid();
        CreateBlocksInGrid();
        SetTypes();
       // Debug.Log("item: " + ToString());


    }
   
    public void SetTypes() 
    {

        Color theColor = colorManager.GetRandomColor();
        for (int i = 0; i < blocks.Length; i++)
        {
            for (int j = 0; j < blocks[i].Length; j++)
            {
               // blocks[i][j].GetComponent<Block>().Type = type;
                blocks[i][j].GetComponent<Block>().SetColor(theColor);

            }
        }
    }
    public override string ToString() {
        string itemGrid = "";
        StringBuilder builder = new StringBuilder();
        builder.Append("the item: ");
        for (int i = 0; i < blocks.Length; i++) {
            for (int j = 0; j < blocks[i].Length; j++) {
                if (blocks[i][j]!=null) {
                    builder.Append("(");
                    builder.Append(i);
                    builder.Append(",");
                    builder.Append(j);
                    builder.Append(")");

                }
            }
        
        }

        itemGrid = builder.ToString();
        return itemGrid;
    }
    

    public void CreateBlocksInGrid() {

        for (int i = 0; i < blocks.Length; i++)
        {
            for (int j = 0; j < blocks[i].Length; j++)
            {
                

                    //Debug.Log("drawing grid" + i + "," + j);
                    GameObject blockObj = Instantiate(blockPrefab);
                //imageObj.transform.localScale *= 8;
                //imageObj.AddComponent<SpriteRenderer>().sprite = theSprite; // chaining again, is this ok?

                blockObj.transform.SetParent(gameObject.transform); //this object's transform. someone else should create the items
                blockObj.transform.localPosition = new Vector3(i, j, 0);



                blocks[i][j] = blockObj;



            }
        }

    }

    
   
    
}
