using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Header("Settings")]
    // How far the player can reach
    public float MaxUseDistance = 1f;
    // The layers the interatction looks for
    public LayerMask[] UseLayers;

    [Header("Player")]
    // The players camera
    public Transform Camera;

    // On use, call the following methods
    public void OnUse()
    {
        // Checks for door interaction
        DoorRaycast();
        // Checks for bed interaction
        BedRaycast();
        // Checks for computer interaction
        ComputerRaycast();
    }

    // Checks for door interaction
    public void DoorRaycast()
    {
        // If interacts w/ door object, continue
        if (
            Physics.Raycast(
                Camera.position,
                Camera.forward,
                out RaycastHit hit,
                MaxUseDistance,
                UseLayers[0]
            )
        )
        {
            // Get script, then based on doors positioning, open or close
            if (hit.collider.TryGetComponent<Door>(out Door door))
            {
                if (door.isOpen)
                {
                    // If door is open, close
                    door.Close();
                }
                else
                {
                    // If door is closed, open
                    door.Open();
                }
            }
        }
    }

    // Checks for bed interaction
    public void BedRaycast()
    {
        // If interacts w/ bed object, continue
        if (
            Physics.Raycast(
                Camera.position,
                Camera.forward,
                out RaycastHit hit,
                MaxUseDistance,
                UseLayers[1]
            )
        )
        {
            // Get script, then call sleep method
            if (hit.collider.TryGetComponent<Bed>(out Bed bed))
            {
                // Bed sleep method
                bed.Sleep();
            }
        }
    }

    // Checks for computer interaction
    public void ComputerRaycast()
    {
        // If interacts w/ computer object, continue
        if (
            Physics.Raycast(
                Camera.position,
                Camera.forward,
                out RaycastHit hit,
                MaxUseDistance,
                UseLayers[3]
            )
        )
        {
            // Get script, then call computer method
            if (hit.collider.TryGetComponent<Computer>(out Computer computer))
            {
                // Computer interact method
                computer.Interact();
            }
        }
    }
}
