using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

[InitializeOnLoad]
public class PlayFromHere : Editor {

    static PlayFromHere()
    {
        SceneView.onSceneGUIDelegate += OnSceneGUI;
    }
   
    static void OnSceneGUI(SceneView sceneview)
    {
        Event e = Event.current;

        Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);

        if (Event.current.type == EventType.MouseDown && e.button == 1 && e.shift)
        {
            GenericMenu menu = new GenericMenu();
            menu.AddItem(new GUIContent("Play From Here"), false, Callback, ray);
            //menu.AddItem(new GUIContent("Item 2"), false, Callback, 2);
            menu.ShowAsContext();
        }
    }

    static void Callback(object obj)
    {
        Ray ray = (Ray)obj;

        PlayFromEditor playfrom = ScriptableObject.CreateInstance<PlayFromEditor>();

        AssetDatabase.CreateAsset(playfrom, "Assets/PlayFromEditor.asset");
        AssetDatabase.SaveAssets();

        //Usage 1. Require Navmesh and Layers Setup.
        //Use the ray to cast into the world and store the hit point
        //The ray ignores the defined layers, and if it hits an object marked as Walkable or Terrain
        //will get the closest nav mesh hit position.

        //RaycastHit rayHit;
        //if (Physics.Raycast(ray, out rayHit, Mathf.Infinity, ~(1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Ignore Raycast") | 1 << LayerMask.NameToLayer("Water"))))
        //{
            //if (rayHit.transform.gameObject.layer == LayerMask.NameToLayer("Walkable") || rayHit.transform.gameObject.layer == LayerMask.NameToLayer("Terrain"))
            //{
            //    UnityEngine.AI.NavMeshHit hitMouseNavPoint;
            //    if (UnityEngine.AI.NavMesh.SamplePosition(rayHit.point, out hitMouseNavPoint, 1, -1))
            //    {
                    playfrom.StartPos = ray.origin;
                    playfrom.IsPlayFromHere = true;
            //    }
            //}

        //    Debug.DrawRay(ray.origin, ray.direction, Color.red, 3f);
        //}

        //Usage 2. 
        //Just store the ray origin

        //playfrom.StartPos = ray.origin;
        //playfrom.IsPlayFromHere = true;


        EditorApplication.isPlaying = true;

    }
}



