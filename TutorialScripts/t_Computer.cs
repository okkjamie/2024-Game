using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class t_Computer : MonoBehaviour
{
    [Header("Computer Objects")]
    // GUI elements
    public GameObject screen;

    [Header("Player Scripts")]
    public PlayerMovement playerMovement;
    public t_PlayerActions t_playerActions;
    public HeadbobSystem headbob;

    [Header("Audio")]
    // Source of the audio
    public AudioSource laptopSource;
    // Audio Clip
    public AudioClip clip;

    // States
    bool open = false;

    [Header("Debug")]
    // These are debug to know what you've selected 
    public string currentlySelectedPlace = null;
    public string currentlySelectedAnomaly = null;

    [Header("GUI")]
    // The GUI where you chose where the anomaly is
    public GameObject whereAnomalyGUI;
    // The GUI where you chose the type of anomaly
    public GameObject pickAnomalyGUI;
    
    [Header("Models")]
    // The laptop model
    public GameObject laptop;
    // The alarm clock model
    public GameObject alarm;
    // The computer model
    public GameObject comp;

    // ID numbers for entered place and anomaly
    int enteredPlace;
    int enteredAnomaly;

    void Update()
    {
        // If Esc pressed and computer is open, run close computer method
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Checks if open
            if (open)
            {
                Close();
            }
        }
    }

    // If interacted with computer and computer is closed, run open computer method
    public void Interact()
    {   // Checks if closed
        if (!open)
        {
            Open();
        }
    }

    void Open()
    {
        // Specifys computer is open
        open = true;

        // Opens computer GUI
        screen.SetActive(true);

        // Locks scripts
        ScriptAdjust();

        // Specifys computer audio
        laptopSource.clip = clip;
        // Plays computer audio
        laptopSource.Play();

        // Unlocks and reveals cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Close()
    {
        // Specifys computer is closed
        open = false;

        // Closes computer GUI
        screen.SetActive(false);

        // Unlocks scripts
        ScriptAdjust();

        // Locks and hides cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Emables or Disables movement and input scripts based on interaction with computer
    public void ScriptAdjust()
    {
        playerMovement.enabled = !playerMovement.enabled;
        headbob.enabled = !headbob.enabled;
        t_playerActions.enabled = !t_playerActions.enabled;
    }

    // When selecting the anomalys location, store info
    public void OnClickedPlace(Button button)
    {
        currentlySelectedPlace = button.name;
        int.TryParse(currentlySelectedPlace, out enteredPlace);
    }

    // When selecting the anomaly type, store info
    public void OnClickedAnomaly(Button button)
    {
        currentlySelectedAnomaly = button.name;
        int.TryParse(currentlySelectedAnomaly, out enteredAnomaly);
    }

    // When opening next GUI, pass info through to manager
    public void EnteredNext()
    {
        // Gets the time manager
        t_TimeManager time = alarm.GetComponent(typeof(t_TimeManager)) as t_TimeManager; 
        // Passes info to manager
        time.enteredAnomaly = enteredAnomaly;

        // Close current GUI, opens next GUI
        whereAnomalyGUI.SetActive(true);
        pickAnomalyGUI.SetActive(false);
    }

    // When closing GUI, pass info through to manager
    public void CloseGUI()
    {
       UpdateTime();

        // Close current GUI, opens first GUI for when the computer is next used
        whereAnomalyGUI.SetActive(false);
        pickAnomalyGUI.SetActive(true);

        Close();
    }

    public void UpdateTime()
    {
         // Gets the time manager
        t_TimeManager time = alarm.GetComponent(typeof(t_TimeManager)) as t_TimeManager; 
        // Passes info to manager
        time.enteredPlace = enteredPlace;
    }
}
