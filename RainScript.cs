using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    public AudioSource thunderSource;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FootstepSounds());
    }

    IEnumerator FootstepSounds()
    {
         thunderSource.clip = clip;
            thunderSource.volume = Random.Range(0.65f, 0.85f);
            thunderSource.pitch = Random.Range(0.8f, 1.2f);
            thunderSource.Play();
            yield return new WaitForSeconds(Random.Range(20, 45));
            StartCoroutine(FootstepSounds());
  
    }
}
