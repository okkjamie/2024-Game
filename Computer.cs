using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public GameObject screen;
    bool open = false;

    public PlayerActions playerActions;
    public PlayerMovement playerMovement;
    public HeadbobSystem headbob;

    public AudioSource laptopSource;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(open) {Close();}
        }
    }

    public void Interact()
    {
        Debug.Log("Interating"); 
        if(!open)
        {
            Open();
        }
    }

    void Open()
    {
        open = true;
        screen.SetActive(true);
        playerMovement.enabled = !playerMovement.enabled;
        playerActions.enabled = !playerActions.enabled;
        headbob.enabled = !headbob.enabled;
        laptopSource.clip = clip;
        laptopSource.Play();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Close()
    {
        open = false;
        screen.SetActive(false);
        playerMovement.enabled = !playerMovement.enabled;
        playerActions.enabled = !playerActions.enabled;
        headbob.enabled = !headbob.enabled;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
            