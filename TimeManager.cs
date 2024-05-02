using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [Header("Clock")]
    // What the current time is
    public float currentTime;
    // The Text component of the clock
    public TMP_Text clockText;
    // What the clock shows
    public string clockTextVar;

    [Header("Anomaly Types")]
    // The current anomaly decided by the manager
    public float currentAnomaly;
    // The entered anomaly decided by the player
    public float enteredAnomaly;

    [Header("Anomaly Locations")]
    // The current anomaly's location decided by the manager
    public float currentPlace;
    // The entered anomaly's location decided by the player
    public float enteredPlace;

    [Header("Anomaly Managers")]
    // The manager of the anomaly objects
    public GameObject manager;

    // States
    bool placeFound;
    bool anomalyFound;
    bool isAnomaly;
    bool isAnomalyFound;

    // Sets everything to false && 0 
    void Start()
    {
        // Chooses a new anomaly when the game starts
        NewAnomaly();
        currentTime = 0;
        isAnomalyFound = false;
        placeFound = false;
    }

    public void AnomalyCheck()
    {   
        // Sets state to false
        isAnomalyFound = false;

        // If selected anomaly matches with manager, set to true
        if (currentAnomaly == enteredAnomaly)
        {
            anomalyFound = true;
        }

        // If selected locaiton matches with manager, set to true
        if (currentPlace == enteredPlace)
        {
            placeFound = true;
        }
        
        // If both the anomnaly's type and location is found, set to true
        if (placeFound && anomalyFound)
        {
            // Sets state to true
            isAnomalyFound = true;
        }

        // Updates clock text to current time
        UpdateClock();
    }

   
    void UpdateClock()
    {
        // If anomaly is found, then update time to the next hour
        if (isAnomalyFound == true)
        {   
            // Adds a hour to time
            currentTime += 1;

            // If current time is equal to 8, the player has won
            if (currentTime == 8)
            {
                // Plays win sequence
                SceneManager.LoadScene(2); 
            }

            // Sets clock time to match current time
            clockTextVar = "0" + currentTime + ":00";
        }
        // If anomaly is not found, then reset time 
        else
        {
            // Sets current time to 0 
            currentTime = 0;
            // Sets clock time to match current time
            clockTextVar = "0" + currentTime + ":00";
        }

        // Sets clock text to clock time
        clockText.text = clockTextVar;

        // Randomaly choses a new anomaly
        NewAnomaly();
    }

    void NewAnomaly()
    {   
        // Reset states 
        isAnomalyFound = false;
        anomalyFound = false;
        placeFound = false;

        // Resets player input
        enteredAnomaly = 0;
        enteredPlace = 0;

        // Contacts the anomaly manager script
        AnomalyManager anomaly = manager.GetComponent(typeof(AnomalyManager)) as AnomalyManager;
        // Chooses a new anomaly
        anomaly.NewAnomaly();

        // Sets current stats to anomalys stats
        isAnomaly = anomaly.isAnomaly;
        currentAnomaly = anomaly.currentAnomaly;
        currentPlace = anomaly.currentLocation;
    }
}