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

    public int currentAnomoly;
    public int enteredAnomoly;

    public int currentPlace;
    public int enteredPlace;
    
    bool placeFound = false;
    bool anomolyFound = false;
    
    void Start()
    {
        NewAnomoly();
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
        NewAnomoly();
        
    }

    void NewAnomoly()
    {
        isAnanomlyFound = false;
        currentAnomoly = Random.Range(1,8);
        currentPlace = Random.Range(1,4);
        anomolyFound = false;
        placeFound = false;
    }

    


}
