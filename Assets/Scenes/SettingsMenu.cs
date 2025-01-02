using System;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public bool shouldPauseGame = false;
    public GameObject settingsPanel;
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    
    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        if (shouldPauseGame)
        {
            Time.timeScale = 0;
        }
    }
    
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        if (shouldPauseGame)
        {
            Time.timeScale = 1;
        }
    }
    
}
