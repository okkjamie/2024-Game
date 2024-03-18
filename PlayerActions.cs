using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{   public Transform Camera;
    public float MaxUseDistance = 1f;
    public LayerMask UseLayers;
    
    public void OnUse()
    {
        Debug.Log("USED!");
        // check if layer is note
        //check if layer is bed
        //check if layer is door

        //else do nothing 
    }
}
