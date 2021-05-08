using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GlobalAudienceSpawner))]
public class GlobalAudienceSpawnerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GlobalAudienceSpawner myScript = (GlobalAudienceSpawner) target;
        if (GUILayout.Button("Spawn Audience Row"))
        {
            myScript.GenerateAudience();
        }
            
        if (GUILayout.Button("Clear Audience Row"))
        {
            myScript.ClearAudience();
        }
            
        if (GUILayout.Button("Fetch Slots"))
        {
            myScript.FetchSlotsSpawners();
        }
        
        if (GUILayout.Button("Reload Slots Spawners"))
        {
            myScript.ReloadSlotSpawners();
        }
        
        if (GUILayout.Button("Set Paths for Character Assets"))
        {
            myScript.SetCharacterPaths();
        }
    }
}