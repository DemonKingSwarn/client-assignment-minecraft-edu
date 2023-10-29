using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [SerializeField] float walkingSpeed = 12f;
    [SerializeField] float sprintingSpeed = 24f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] float bobFreq = 2f;
    [SerializeField] float bobAmp = 0.08f;
    [SerializeField] float tBob = 0f;
    [SerializeField] float groundDistance = 0.4f;
    
    [SerializeField] Transform head;
    [SerializeField] Transform groundCheck;
    
    [SerializeField] LayerMask groundMask;

    [SerializeField] GameObject codePanel;

    Vector3 velocity;
    bool isGrounded;
    float speed;
    bool isCrouching = false;
    bool isPaused = false;
    public bool escapePressedThisFrame = false;

    void Start()
    {
        //speed = 0f;
        //speed += walkingSpeed;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        float isGroundedFloat = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask) ? 1.0f : 0.0f;

        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            speed = sprintingSpeed;
        } else {
            speed = walkingSpeed;
        }

        //Debug.Log(speed);

        if(isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        /*
        tBob += Time.deltaTime * velocity.magnitude * isGroundedFloat;
        head.localPosition = HeadBob(tBob);
        */

        if(Input.GetKey(KeyCode.Escape) && escapePressedThisFrame == false)
        {
            TogglePause();
            escapePressedThisFrame = true;
        }
    }

    Vector3 HeadBob(float time)
    {
        Vector3 pos = Vector3.zero;
        pos.y = Mathf.Sin(time * bobFreq) * bobAmp;
        pos.x = Mathf.Cos(time * bobFreq / 2f) * bobAmp; 
        return pos;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        codePanel.SetActive(isPaused);
        Cursor.visible = isPaused;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
    }
}