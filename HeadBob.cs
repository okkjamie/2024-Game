using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadbobSystem : MonoBehaviour
{
    // Ammount of headbob 
    [Range(0.001f, 0.01f)]
    public float Amount = 0.002f;
    
    // Frequency of the headbob
    [Range(1f, 30f)]
    public float Frequency = 10.0f;

    // Smothness of the headbob
    [Range(10f, 100f)]
    public float Smooth = 10.0f;

    // Starting Position
    Vector3 StartPos;

    void Start()
    {
        //Sets the starting position to the cameras location
        StartPos = transform.localPosition;
    }

    void Update()
    {
        // Checks for input 
        CheckForHeadbobTrigger();

        // Returns camera position to starting position 
        StopHeadbob();
    }

    private void CheckForHeadbobTrigger()
    {
        // Checks if any input keys are down (WASD)
        float inputMagnitude =
            new Vector3(
                Input.GetAxis("Horizontal"),
                0,
                Input.GetAxis("Vertical")).magnitude;

        // If input is greater than 0, start headbob
        if (inputMagnitude > 0)
        {
            //Starts headbob
            StartHeadBob();
        }
    }

    private Vector3 StartHeadBob()
    {
        // Zeros cameras location
        Vector3 pos = Vector3.zero;

        // Randomizes camera direction and positon for the headbob
        pos.y += Mathf.Lerp(
            pos.y,
            Mathf.Sin(Time.time * Frequency) * Amount * 1.4f,
            Smooth * Time.deltaTime
        );
        pos.x += Mathf.Lerp(
            pos.x,
            Mathf.Cos(Time.time * Frequency / 2f) * Amount * 1.6f,
            Smooth * Time.deltaTime
        );
        
        // Sets location variable to the new location variable
        transform.localPosition += pos;

        // End script
        return pos;
    }

    private void StopHeadbob()
    {
        // If no change to headbob (ex. no input), then return
        if (transform.localPosition == StartPos)
            return;

        // Adds the difference to the camera positioning overtime 
        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            StartPos,
            1 * Time.deltaTime
        );
    }
}
