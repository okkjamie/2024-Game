using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using TMPro;

public class GuiManager : MonoBehaviour
{
    bool isFirst;
    bool settingsOpen;

    public AudioMixer audioMixer;
    public Slider audioSlider;

    public LightingSettings lightingSettings;
    public Slider brightnessSlider;

    public GameObject settingsMenu;
    public GameObject mainMenu;
    public GameObject firstGame;

    public TMP_Dropdown dropdown;

    float currentVolume;

    public void Start()
    {
        GameObject tutorial = GameObject.Find("Tutorial");
        tutorial.TryGetComponent<Tutorial>(out Tutorial tutorialScr);
        
        dropdown.value = QualitySettings.GetQualityLevel();

        if(tutorialScr.IsFirst == 0)
        {
            isFirst = true;
            PlayerPrefs.SetFloat("VolumePreference", 30); 
        }
        else
        {
            isFirst = false;
        }

        if (PlayerPrefs.HasKey("VolumePreference"))
        {
            audioSlider.value = PlayerPrefs.GetFloat("VolumePreference");
        }
        else
        {
            audioSlider.value = PlayerPrefs.GetFloat("VolumePreference");
        }
        
        SetVolume(30);
        ChangeLevel();
        
    }
    // Loads the game scene
    public void StartGame()
    {
        if(isFirst)
        {
            firstGame.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene(2);
    }
    // Opens the setting element
    public void SettingsMenu()
    {
        if(settingsOpen)
        {
            settingsOpen = false;
            settingsMenu.SetActive(false);
            mainMenu.SetActive(true);

            PlayerPrefs.SetFloat("VolumePreference", currentVolume); 
        }
        else
        {
            settingsOpen = true;
            settingsMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

    // Opens the credit documentation
    public void Credits()
    {
        Application.OpenURL(
            "https://docs.google.com/document/d/1coMlAxxjbDOvlydSLe1Yh9Oe8ep3FJdbljDSe_B0rOk/edit"
        );
    }

    // Quits the game
    public void Quit()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(2);
    }

    public void SetVolume(float volume)
    {
        volume = audioSlider.value;
        Debug.Log(volume);
        audioMixer.SetFloat("MasterVol", volume);
        currentVolume = volume;
    }

    public void SetBrightness(float brightness)
    {
        brightness = brightnessSlider.value;
        GameObject graphics = GameObject.Find("Global");
        graphics.TryGetComponent<GlobalVolumeManager>(out GlobalVolumeManager GlobalVolumeManagerScr);
        GlobalVolumeManagerScr.ChangeBrightness(brightness);
    }

    public void ChangeLevel()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        Debug.Log(dropdown.value);

        GameObject graphics = GameObject.Find("Global");
        graphics.TryGetComponent<GlobalVolumeManager>(out GlobalVolumeManager GlobalVolumeManagerScr);
        GlobalVolumeManagerScr.ChangeLevel(dropdown.value);
    }
}

