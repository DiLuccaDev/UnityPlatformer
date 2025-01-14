using System;
using UnityEngine;

public class DebugCanvas : MonoBehaviour {

    // FPS Fields
    [Header("FPS")]
    public TMPro.TMP_Text fpsText;
    [SerializeField] private int fpsCurrent = 60;
    [SerializeField] private int fpsInterval = 5;
    private int fpsDefault = 60;
    // Game Speed Fields
    [Header("Game Speed")]
    public TMPro.TMP_Text gameSpeedText;
    [SerializeField] private float gameSpeedCurrent = 1f;
    [SerializeField] private float gameSpeedInterval = 0.1f;
    private float gameSpeedDefault = 1f;

    private void Awake() {
        UpdateFPS();
        UpdateGameSpeed();
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
        fpsCurrent = fpsDefault;
        UpdateFPS();
    }

    private void UpdateFPS() {
        QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
        Application.targetFrameRate = fpsCurrent;
        fpsText.text = $"FPS: {Application.targetFrameRate.ToString()}";
    }
    
    public void IncreaseGameSpeed() {
        gameSpeedCurrent += gameSpeedInterval;
        UpdateGameSpeed();
    }

    public void DecreaseGameSpeed() {
        gameSpeedCurrent -= gameSpeedInterval;
        UpdateGameSpeed();
    }

    public void ResetGameSpeed() {
        gameSpeedCurrent = gameSpeedDefault;
        UpdateGameSpeed();
    }
    
    private void UpdateGameSpeed() {
        Time.timeScale = gameSpeedCurrent;
        gameSpeedText.text = $"Speed: {Time.timeScale}";
    }
}