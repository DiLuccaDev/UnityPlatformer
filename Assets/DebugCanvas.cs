using System;
using UnityEngine;

public class DebugCanvas : MonoBehaviour {
    public TMPro.TMP_Text fpsText;

    // Fields
    [SerializeField] int fpsCurrent = 60;
    [SerializeField] int fpsInterval = 5;

    private void Awake() {
        UpdateFPS();
    }

    public void IncreaseFPS() {
        fpsCurrent += fpsInterval;
        UpdateFPS();
    }

    public void DecreaseFPS() {
        fpsCurrent -= fpsInterval;
        UpdateFPS();
    }

    public void ResetFPS() {
        fpsCurrent = 60;
        UpdateFPS();
    }

    private void UpdateFPS() {
        QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
        Application.targetFrameRate = fpsCurrent;
        fpsText.text = $"FPS: {Application.targetFrameRate.ToString()}";
    }
}