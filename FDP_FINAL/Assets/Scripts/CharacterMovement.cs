using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public Vector3 jumpVelocity;
    public Camera playerCamera;

    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    

    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;
    public bool grounded;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        
    }

    
    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection =(Vector3.Cross(playerCamera.transform.right, Vector3.up) * Input.GetAxis("Vertical")) + (playerCamera.transform.right * Input.GetAxis("Horizontal"));


        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();



        ySpeed += Physics.gravity.y * Time.deltaTime;

       
        
        if(grounded && jumpVelocity.y < 0)
        {
            jumpVelocity.y = 0f;
            
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        grounded = characterController.isGrounded;

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            
            ySpeed = 0f;
            jumpVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        jumpVelocity.y += gravity * Time.deltaTime;
        characterController.Move(jumpVelocity * Time.deltaTime);

       
    }
}
