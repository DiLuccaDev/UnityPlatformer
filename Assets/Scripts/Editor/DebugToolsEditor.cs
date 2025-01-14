using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DebugCanvas))]
public class DebugToolsEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        DebugCanvas debugCanvas = (DebugCanvas)target;

        // FPS
        if (GUILayout.Button("Increase FPS")) {
            debugCanvas.IncreaseFPS();
        }

        if (GUILayout.Button("Decrease FPS")) {
            debugCanvas.DecreaseFPS();
        }

        if (GUILayout.Button("Reset FPS")) {
            debugCanvas.ResetFPS();
        }

        // Game Speed
        if (GUILayout.Button("Increase Game Speed")) {
            debugCanvas.IncreaseGameSpeed();
        }

        if (GUILayout.Button("Decrease Game Speed")) {
            debugCanvas.DecreaseGameSpeed(); 
        }

        if (GUILayout.Button("Reset Game Speed")) {
            debugCanvas.ResetGameSpeed();
        }
    }
}