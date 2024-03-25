using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public GameObject Alarm;
    public GameObject cutscene;
    public PlayerActions playerActions;
    public PlayerMovement playerMovement;
    public HeadbobSystem headbob;

    public AudioSource alarmSource;
    public AudioClip clip;

    bool canSleep;
    // Start is called before the first frame update
    void Start()
    {
        canSleep = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sleep()
    {
        StartCoroutine(SleepCutscene());
    }

    IEnumerator SleepCutscene()
    {
        if(canSleep)
        {
            canSleep = false;
            TimeManager time = Alarm.GetComponent(typeof(TimeManager)) as TimeManager;
            time.AnomolyCheck();
            Debug.Log("Sleep!");
            cutscene.SetActive(true);
            playerMovement.enabled = !playerMovement.enabled;
            playerActions.enabled = !playerActions.enabled;
            headbob.enabled = !headbob.enabled;
            yield return new WaitForSeconds(5f);
            playerMovement.enabled = !playerMovement.enabled;
            playerActions.enabled = !playerActions.enabled;
            headbob.enabled = !headbob.enabled;
            cutscene.SetActive(false);
            Debug.Log("Wake!");

            alarmSource.clip = clip;
            alarmSource.volume = Random.Range(0.35f, 0.65f);
            alarmSource.pitch = Random.Range(0.8f, 1.2f);
            alarmSource.Play();
            yield return new WaitForSeconds(5f);
            alarmSource.Stop();

            yield return new WaitForSeconds(7f);
            canSleep = true;
        }
        

    }
}
