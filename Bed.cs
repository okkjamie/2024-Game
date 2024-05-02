using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    [Header("Objects")]
    public GameObject Alarm;
    public GameObject cutscene;

    [Header("Scripts")]
    public PlayerActions playerActions;
    public PlayerMovement playerMovement;
    public HeadbobSystem headbob;

    [Header("Sound")]
    public AudioSource alarmSource;
    public AudioClip clip;

    // States
    bool canSleep = true;
    
    // Starts the sleep cutscene
    public void Sleep()
    {
        StartCoroutine(SleepCutscene());
    }

    // Emables or Disables movement and input scripts while in cutscene 
    public void ScriptAdjust()
    {
        playerMovement.enabled = !playerMovement.enabled;
        playerActions.enabled = !playerActions.enabled;
        headbob.enabled = !headbob.enabled;
    }

    // Alarm clock sound
    public void SoundStart()
    {
        // Specifiys clip
        alarmSource.clip = clip;

        // Randomizes clip
        alarmSource.volume = Random.Range(0.35f, 0.65f);
        alarmSource.pitch = Random.Range(0.8f, 1.2f);

        // Plays clip
        alarmSource.Play();
    }

    // Stops the alarm clock sound
    public void SoundStop()
    {   
        // Stops clip
        alarmSource.Stop();
    }


    IEnumerator SleepCutscene()
    {
        if(canSleep)
        {
            // Stops player from sleeping straight away 
            canSleep = false;

            // Checks values and updates time based on player input
            TimeManager time = Alarm.GetComponent(typeof(TimeManager)) as TimeManager;
            time.AnomalyCheck();
            
            // Activates cutscene 
            cutscene.SetActive(true);

            // Disables scripts
            ScriptAdjust();
            
            // Waits 5 seconds
            yield return new WaitForSeconds(5f);
            
            // Ends Cutscene
            cutscene.SetActive(false);

            // Enables Scripts
            ScriptAdjust();

            // Plays Alarm 
            SoundStart();
            yield return new WaitForSeconds(5f);
            SoundStop();

            // Allows player to sleep again
            yield return new WaitForSeconds(10f);
            canSleep = true;
        }
    }
}