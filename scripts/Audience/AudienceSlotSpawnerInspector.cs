using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    [CustomEditor(typeof(AudienceSlotSpawner))]
    public class AudienceSlotSpawnerInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            AudienceSlotSpawner myScript = (AudienceSlotSpawner) target;
            
            if (GUILayout.Button("Clear Audience Row"))
            {
                myScript.DestroySlotsSpawns();
            }
            
            
            if (GUILayout.Button("Clear Slots"))
            {
                myScript.ClearSlots();
            }
            
            if (GUILayout.Button("Clear character pool"))
            {
                myScript.ClearCharacters();
            }
            
            if (GUILayout.Button("Spawn Audience Row"))
            {
                myScript.SpawnAtSlots();
            }
            
            if (GUILayout.Button("Fetch Slots"))
            {
                myScript.FetchSlots();
            }
            
            if (GUILayout.Button("Load Characters"))
            {
                myScript.LoadCharacters();
            }
        }
    }
}
