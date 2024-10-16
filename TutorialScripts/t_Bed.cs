using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t_Bed : MonoBehaviour
{
    [Header("Objects")]
    public GameObject Alarm;
    public GameObject cutscene;

    [Header("Scripts")]
    public t_PlayerActions t_playerActions;
    public PlayerMovement playerMovement;
    public HeadbobSystem headbob;

    [Header("Sound")]
    public AudioSource alarmSource;
    public AudioClip clip;

    [Header("Tutorial")]
    public GameObject[] t1_messages;
    public GameObject[] t2_messages;

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
        t_playerActions.enabled = !t_playerActions.enabled;
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
            t_TimeManager time = Alarm.GetComponent(typeof(t_TimeManager)) as t_TimeManager;
            time.AnomalyCheck();
            
            // Activates cutscene 
            cutscene.SetActive(true);

            // Hides old tutorial messages and reveals new ones
            for (int i = 0; i < 4; i++) 
            {
                t1_messages[i].SetActive(false);
                t2_messages[i].SetActive(true);
            }

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