using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    [Header("Rain Sources")]
    // The source of the thunder (for 3D Reverb)
    public AudioSource thunderSource; 
    // The thunder sound effect
    public AudioClip clip; 

    void Start()
    {
        // Starts the repeating sounds
        StartCoroutine(FootstepSounds()); 
    }

    IEnumerator FootstepSounds()
    {
        // Specifys Clip
        thunderSource.clip = clip; 
        
        // Randomize volume
        thunderSource.volume = Random.Range(0.65f, 0.85f); 
        
        // Randomize pitch (how deep or high it sounds)
        thunderSource.pitch = Random.Range(0.8f, 1.2f); 
        
        // Plays the audio source
        thunderSource.Play(); 

        // Waits a random time then plays
        yield return new WaitForSeconds(Random.Range(20, 45)); 

        // Repeats the thunder sound effect
        StartCoroutine(FootstepSounds()); 
    }
}
