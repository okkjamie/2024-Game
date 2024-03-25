using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen;
    public float targetAngleOpen = 105f; 
    public float targetAngleClosed = 0f; 
    public float rotationSpeed = 90f; 

    public AudioSource[] openClose;
    public AudioClip[] clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        isOpen = true;
        StartCoroutine(RotateOpen());
    }
    
    IEnumerator RotateOpen()
    {
        float currentAngle = 0f;
        
        openClose[0].clip = clip[0];
        openClose[0].volume = Random.Range(0.5f, 0.6f);
        openClose[0].pitch = Random.Range(0.8f, 1.2f);
        openClose[0].Play();

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
        isOpen = false;
        StartCoroutine(RotateClose());
    }

    IEnumerator RotateClose()
    {
       float currentAngle = 0f;
        while (currentAngle > -targetAngleOpen) 
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            currentAngle -= rotationAmount; 
            transform.Rotate(Vector3.up, -rotationAmount); 
            yield return null;
        }
        openClose[1].clip = clip[1];
        openClose[1].volume = Random.Range(0.5f, 0.6f);
        openClose[1].pitch = Random.Range(0.8f, 1.2f);
        openClose[1].Play();
    }
}

