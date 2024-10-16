using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [Header("Door Settings")]
    // Target angle of door when opened
    public float targetAngleOpen = 105f;
    // Target angle of door when closed
    public float targetAngleClosed = 0f;
    // How fast the door rotates
    public float rotationSpeed = 90f;

    [Header("Sound Sources")]
    // Source of audio
    public AudioSource[] openClose;
    // Audio clips
    public AudioClip[] clip;

    // States 
    public bool isOpen = false;

    public void Interact()
    {
        if(isOpen == true)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public void Open()
    {
        // Specifys door is open for interaction
        isOpen = true;
        // Opens door 
        StartCoroutine(RotateOpen());
    }

    IEnumerator RotateOpen()
    {
        // Gets current angle
        float currentAngle = 0f;

        // Plays open audio
        DoorAudio(0);

        // While door is not equal to target angle, continue to open overtime 
        while (currentAngle < targetAngleOpen)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            currentAngle += rotationAmount;
            transform.Rotate(Vector3.up, rotationAmount);
            yield return null;
        }
    }

    public void Close()
    {
        // Specifys door is open for interaction
        isOpen = false;
        // Closes door 
        StartCoroutine(RotateClose());
    }

    IEnumerator RotateClose()
    {   
        // Gets current angle
        float currentAngle = 0f;

        // While door is not equal to target angle, continue to close overtime 
        while (currentAngle > -targetAngleOpen)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            currentAngle -= rotationAmount;
            transform.Rotate(Vector3.up, -rotationAmount);
            yield return null;
        }

        // Plays closing audio
         DoorAudio(1);
        
        
    }

    public void DoorAudio(int currentClip)
    {   
        // Specifys clip based on audio clip is called 
        openClose[currentClip].clip = clip[currentClip];

        // Randomizes Audio
        openClose[currentClip].volume = Random.Range(0.5f, 0.6f);
        openClose[currentClip].pitch = Random.Range(0.8f, 1.2f);

        // Plays sound
        openClose[currentClip].Play();
    }
}

