using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public float currentTime;
    public bool isAnanomlyFound;
    public TMP_Text clockText;
    public string clockTextVar;

    public float currentAnomoly;
    public float enteredAnomoly;

    public float currentPlace;
    public float enteredPlace;
    
    bool placeFound = false;
    bool anomolyFound = false;
    bool isAnomaly;

    public GameObject manager;
    
    void Start()
    {
        NewAnomaly();
        currentTime = 0;
        isAnanomlyFound = false;
    }

    public void AnomolyCheck()
    {   
        if(currentAnomoly == enteredAnomoly){anomolyFound = true;}
        if(currentPlace == enteredPlace){placeFound = true;}
        
        if(placeFound && anomolyFound){isAnanomlyFound = true;}
        else{isAnanomlyFound = false;}

        UpdateClock();
    }

    //updates clock text to current time
    void UpdateClock()
    {
        if(isAnanomlyFound == true)
        {
            currentTime += 1;
            if(currentTime == 8)
            {
                SceneManager.LoadScene(2); // plays win sequence    
            }

            clockTextVar = "0" + currentTime + ":00";
        }
        else
        {
            currentTime = 0;
            clockTextVar = "0" + currentTime + ":00";
            
        }

        clockText.text =  clockTextVar;
        NewAnomaly();  
    }

    void NewAnomaly()
    {
        isAnanomlyFound = false;
        anomolyFound = false;
        placeFound = false;

        enteredAnomoly = 0;
        enteredPlace = 0;

        AnomalyManager anomaly = manager.GetComponent(typeof(AnomalyManager)) as AnomalyManager;
        anomaly.NewAnomaly();
        isAnomaly = anomaly.isAnomaly;
        currentAnomoly = anomaly.currentAnomaly;
        currentPlace = anomaly.currentLocation;

    }
}
