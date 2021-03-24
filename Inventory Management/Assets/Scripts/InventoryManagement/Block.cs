using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public string type = "";
    public Color color;
    SpriteRenderer sprite;
    //getters and setters shorthand

    private void Start()
    {
    }
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();

    }

    public string Type { get => this.type; set => this.type = value; }

    public Color GetColor()
    {
        return this.color;
    }

    public void SetColor(Color value)
    {
        this.color = value;
        sprite.color = color;

    }
}

