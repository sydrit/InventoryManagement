using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorManager : MonoBehaviour
{
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Color GetRandomColor() {
        int rand = Random.Range(0, 5);
       
        Color color = Color.white;
        switch (rand)
        {
            case 0:
                color = color1;
               
                break;
            case 1:
                color = color2;
               
                break;
            case 2:
                color = color3;
              
                break;
            case 3:
                color = color4;
               
                break;
            case 4:
                color = color5;
                
                break;

        }
        return color;

    }
}
