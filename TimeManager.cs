using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public float currentTime;
    public bool isAnanomlyFound;
    public TMP_Text clockText;
    public string clockTextVar;

    //sets time to 0 
    void Start()
    {
        currentTime = 0;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
             AnomolyCheck();
        }
    }

    //checks if anomoly is found, if found update time, if not reset to 0 
    public void AnomolyCheck()
    {
        if(isAnanomlyFound)
        {
            currentTime += 1;
            if(currentTime > 9)
            {
                clockTextVar = currentTime + ":00";
            }
            else
            {
                 clockTextVar = "0" + currentTime + ":00";
            }
        }
        else
        {
            currentTime = 0;
            if(currentTime > 9)
            {
                clockTextVar = currentTime + ":00";
            }
            else
            {
                 clockTextVar = "0" + currentTime + ":00";
            }
        }

        UpdateClock();
    }

    //updates clock text to current time
    void UpdateClock()
    {
        clockText.text =  clockTextVar;
    }

}
