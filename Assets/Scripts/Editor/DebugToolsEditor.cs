using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DebugCanvas))]
public class DebugToolsEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        
        DebugCanvas debugCanvas = (DebugCanvas)target;

        if (GUILayout.Button("Increase FPS")) {
            debugCanvas.IncreaseFPS();
        }

        if (GUILayout.Button("Decrease FPS")) {
            debugCanvas.DecreaseFPS();
        }

        if (GUILayout.Button("Reset FPS")) {
            debugCanvas.ResetFPS();
        }
    }
}