using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        // Finds target position
        Vector3 direction = target.position - transform.position;

        // Calculates direction to look in based on target position
        Quaternion rotation = Quaternion.LookRotation(direction);

        // Rotates towards target
        transform.rotation = rotation;
    }
}
