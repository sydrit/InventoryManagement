using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CompositeBehavior))]

public class CompositeBehaviorEditor : Editor
{

    private FlockBehavior adding;

    private FlockBehavior[] Remove(int index, FlockBehavior[] old)
    {
        // Remove this behaviour
        var current = new FlockBehavior[old.Length - 1];

        for (int y = 0, x = 0; y < old.Length; y++)
        {
            if (y != index)
            {
                current[x] = old[y];
                x++;
            }
        }

        return current;
    }

    public override void OnInspectorGUI()
    {
        // Setup
        var current = (CompositeBehavior)target;
        EditorGUILayout.BeginHorizontal();

        // Draw
        if (current.behaviors == null || current.behaviors.Length == 0)
        {
            EditorGUILayout.HelpBox("No behaviours attached.", MessageType.Warning);
            EditorGUILayout.EndHorizontal();
        }
        else
        {
            EditorGUILayout.LabelField("Behaviours");
            EditorGUILayout.LabelField("Weights");

            EditorGUILayout.EndHorizontal();

            for (int i = 0; i < current.behaviors.Length; i++)
            {
                // Draw index
                EditorGUILayout.BeginHorizontal();

                if (GUILayout.Button("Remove") || current.behaviors[i] == null)
                {
                    // Remove this behaviour
                    current.behaviors = Remove(i, current.behaviors);
                    break;
                }

                current.behaviors[i] = (FlockBehavior)EditorGUILayout.ObjectField(current.behaviors[i], typeof(FlockBehavior), false);
                EditorGUILayout.Space(30);
                current.weights[i] = EditorGUILayout.Slider(current.weights[i], 0, 10);

                EditorGUILayout.EndHorizontal();
            }
        }

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Add behaviour...");
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        adding = (FlockBehavior)EditorGUILayout.ObjectField(adding, typeof(FlockBehavior), false);

        if (adding != null)
        {
            // add this item to the array
            var oldBehaviours = current.behaviors;
            current.behaviors = new FlockBehavior[oldBehaviours.Length + 1];
            var oldWeights = current.weights;
            current.weights = new float[oldWeights.Length + 1];

            for (int i = 0; i < oldBehaviours.Length; i++)
            {
                current.behaviors[i] = oldBehaviours[i];
                current.weights[i] = oldWeights[i];
            }

            current.behaviors[oldBehaviours.Length] = adding;
            current.weights[oldWeights.Length] = 1;

            adding = null;
        }
    }
}



//public override void OnInspectorGUI()
//{
//    CompositeBehavior cb = (CompositeBehavior)target;

//    // EditorGUILayout.BeginHorizontal();

//    //check for behaviors
//    if (cb.behaviors == null || cb.behaviors.Length == 0)
//    {
//        EditorGUILayout.HelpBox("No behaviors in array", MessageType.Warning); //not working

//    }
//    else
//    {
//        EditorGUILayout.BeginHorizontal();
//        EditorGUILayout.LabelField("Number", GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
//        EditorGUILayout.LabelField("Behaviors", GUILayout.MinWidth(60f));
//        EditorGUILayout.LabelField("Weights", GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
//        EditorGUILayout.EndHorizontal();

//        for (int i = 0; i < cb.behaviors.Length; i++)
//        {
//            EditorGUILayout.BeginHorizontal();
//            EditorGUILayout.LabelField(i.ToString(), GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
//            cb.behaviors[i] = (FlockBehavior)EditorGUILayout.ObjectField(cb.behaviors[i], typeof(FlockBehavior), false, GUILayout.MinWidth(60f));
//            cb.weights[i] = EditorGUILayout.FloatField(cb.weights[i], GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
//            EditorGUILayout.EndHorizontal();
//        }
//    }
//}