using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable {
    public void Interact();
}

public class PlayerActions : MonoBehaviour
{
    public GameObject mainCamera;
    private GameObject objectClicked;
    public GameObject flashlight;
    public KeyCode InteractKeyCode;
    public KeyCode Flashlight;

    public Transform InteractorSource;
    public float InteractRange;

    public GameObject text;
    bool interactText;

    void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        
        // Single Raycast check for both interaction text and input
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactText = true;
                
                // Check if 'E' key is pressed for interaction
                if (Input.GetKeyDown(InteractKeyCode))
                {
                    interactObj.Interact();
                }
            }
            else
            {
                interactText = false;
            }
        }
        else
        {
            interactText = false;
        }

        // Only update the text's active state if necessary
        if (text.activeSelf != interactText)
        {
            text.SetActive(interactText);
        }

        if (Input.GetKeyDown(Flashlight)) // Toggle flashlight
        {
            if (flashlight.activeSelf )
                  flashlight.SetActive(false);
            else
                 flashlight.SetActive(true);
        }
    }
}

