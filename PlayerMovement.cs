using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Player")]
    public Transform playerCamera;
    public Transform groundCheck;

    [Header("Mouse Settings")]
    public float mouseSensitivity = 3.5f;
    public float mouseSmoothTime = 0.01f;

    [Header("Movement Settings")]
    public float Speed = 6.0f;
    public float moveSmoothTime = 0.1f;
    
    [Header("World Settings")]
    public float gravity = -30f;
    public LayerMask ground;  

    [Header("Audio")]
    public AudioSource footstepSource;
    public AudioClip clip;

    // States 
    bool isGrounded;
    bool footstepPlayed;
    
    // Angles the camera can look
    float cameraCap;

    // Mouse States 
    Vector2 currentMouseDelta;
    Vector2 currentMouseDeltaVelocity;
    
    // Player Controller
    CharacterController controller;

    // Movement
    float velocityY;
    Vector2 currentDir;
    Vector2 currentDirVelocity;
    Vector3 velocity;

    void Start()
    {
        // Gets the player controller component
        controller = GetComponent<CharacterController>();

        // Locks and hides the cursor 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
 
    void Update()
    {
        // Updates mouse input
        UpdateMouse();

        // Updates WASD movement
        UpdateMove();
    }
 
    void UpdateMouse()
    {
        // Gets input based on mouse movement (X & Y)
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        // Smooths mouse movement overtime, so it isnt jerky
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
    
        // Calculates new camera rotation based on Y movement 
        cameraCap -= currentMouseDelta.y * mouseSensitivity;

        // Locks Y rotation between -90 and 90 degrees
        cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f);

        // Calculates camera rotation
        playerCamera.localEulerAngles = Vector3.right * cameraCap;

        // Rotates camera based on calculations
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }
 
    public void UpdateMove()
    {
        // Checks if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, ground);
    
        // Normalizes player input (WASD)
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        // Starts player audio 
        Footsteps();

        // Smooths movement from last movement to new movement over time.
        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        // Gravity 
        velocityY += gravity * 2f * Time.deltaTime;
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * Speed + Vector3.up * velocityY;

        // Moves player 
        controller.Move(velocity * Time.deltaTime);

        // If player is not grounded, increase gravity 
        if(isGrounded! && controller.velocity.y < -1f)
        {
            velocityY = -8f;
        }
    }

    void Footsteps()
    {   // If player moving, start footsteps sounds
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            StartCoroutine(FootstepSounds());
        }
        // If player moving, start footsteps sounds
        else if( Input.GetAxisRaw("Vertical") != 0)
        {
            StartCoroutine(FootstepSounds());
        }
        // If player is not moving, stop footsteps sounds
        else
        {
            // Resets coroutine 
            footstepPlayed = false;
            StopCoroutine(FootstepSounds());
        }
    }

    IEnumerator FootstepSounds()
    {
        if(!footstepPlayed)
        {
            // Stops overlapping audio playing 
            footstepPlayed = true;

            // Specifys footstep noise
            footstepSource.clip = clip;

            // Randomizes volume and pitch 
            footstepSource.volume = Random.Range(0.025f, 0.05f);
            footstepSource.pitch = Random.Range(0.8f, 1.2f);

            // Plays sound
            footstepSource.Play();

            // Waits for audio file to stop
            yield return new WaitForSeconds(0.9f);

            // Resets coroutine
            footstepPlayed = false;
        }
  
    }
}
