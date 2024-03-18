using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen;
    public float targetAngleOpen = 105f; 
    public float targetAngleClosed = 0f; 
    public float rotationSpeed = 90f; 

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
    }
}

