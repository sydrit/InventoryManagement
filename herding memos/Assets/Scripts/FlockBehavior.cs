using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehavior : ScriptableObject
{

    public abstract Vector2 CalulateMove(FlockAgent agent, List<Transform> context, Flock flock);


    
}
