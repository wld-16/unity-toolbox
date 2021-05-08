using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    [CustomEditor(typeof(DamageLog))]
    public class DamageLogInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            DamageLog myScript = (DamageLog) target;
            if (GUILayout.Button("Capture damage"))
            {
                myScript.CaptureLog();
            }
        }
    }
}