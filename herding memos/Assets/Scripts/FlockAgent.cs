using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

[RequireComponent (typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    [SerializeField]
    private bool stunned;
    [SerializeField]
    private bool scared; // recently avoided an obstacle
                         // public bool Scared { get { return scared; } }
    private Color color;

    Collider2D agentCollider;
    public Collider2D AgentCollider { get { return agentCollider; } }

    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }
    public void Initialize(Flock flock)
    {
        agentFlock = flock;

    }

    public bool IsScared() {
        return scared;
    }
    public void SetScared(bool s) {

        scared = s;
        if (scared)
        {
            SetColor(Color.yellow);
        }
        else
            SetColor(Color.white);
    }
    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }
    public void Move(Vector2 velocity) {

        int stunFactor = 1;
        if (stunned && scared) { //redundancy here
            stunFactor = 0;
        }
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime * stunFactor;
        
    }

    public void Stun()
    {

        StartCoroutine(StunCoroutine());

    }
    public IEnumerator StunCoroutine()
    {
//        Debug.Log("stunned!");
        float duration = 3f;

        //  yield return new WaitForSeconds(delay);
        stunned = true;

        yield return new WaitForSeconds(duration);
        stunned = false;
        SetScared(false);
        //  SetColor(Color.white);



    }
    public void SetColor(Color c) {

        color = c;
        GetComponentInChildren<SpriteRenderer>().color = c;
    }
}
