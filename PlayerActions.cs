using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{   public Transform Camera;
    public float MaxUseDistance = 1f;
    public LayerMask[] UseLayers;
    
    public void OnUse()
    {
        Debug.Log("USED!");
        DoorRaycast();
        BedRaycast();
        ComputerRaycast();
    }

    public void DoorRaycast()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers[0]))
        {
            if (hit.collider.TryGetComponent<Door>(out Door door))
            {
                if (door.isOpen)
                {
                    door.Close();
                }
                else
                {
                    door.Open();
                }
            }
        }
    }

    public void BedRaycast()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers[1]))
        {
            if (hit.collider.TryGetComponent<Bed>(out Bed bed))
            {
                bed.Sleep();
            }
        }
    }

    public void ComputerRaycast()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers[3]))
        {
            if(hit.collider.TryGetComponent<Computer>(out Computer computer))
            {
                computer.Interact();
            }
        }
    }
}
