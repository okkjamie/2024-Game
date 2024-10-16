using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    [Header("Computer Objects")]
    // GUI elements
    public GameObject screen;

    [Header("Player Scripts")]
    public PlayerActions playerActions;
    public PlayerMovement playerMovement;
    public HeadbobSystem headbob;

    [Header("Audio")]
    // Source of the audio
    public AudioSource laptopSource;
    // Audio Clip
    public AudioClip clip;

    // States
    bool open = false;

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
        playerActions.enabled = !playerActions.enabled;
    }
}
