using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    [Header("Rain Sources")]
    public AudioSource thunderSource; // The source of the thunder (for 3D Reverb)
    public AudioClip clip; // The thunder sound effect

    void Start()
    {
        StartCoroutine(FootstepSounds()); // Starts the repeating sound 
    }

    IEnumerator FootstepSounds()
    {
        thunderSource.clip = clip; // Specifys Clip
        thunderSource.volume = Random.Range(0.65f, 0.85f); // Randomize volume
        thunderSource.pitch = Random.Range(0.8f, 1.2f); // Randomize pitch (how deep or high it sounds)
        thunderSource.Play(); // Plays the audio source

        yield return new WaitForSeconds(Random.Range(20, 45)); // Waits a random time then plays
        StartCoroutine(FootstepSounds()); // Repeats the thunder sound effect
    }
}
