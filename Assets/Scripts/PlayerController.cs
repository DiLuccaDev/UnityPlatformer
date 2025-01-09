using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float DefaultMovementSpeed = 1f;
    public float DefaultJumpForce = 1f;
    public float Gravity = -9.81f;
    //jump
    
    
    [Header("Ground Check Settings")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    
    // COMPONENTS
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform playerMesh;
    
    private Vector3 velocity;
    private float currMovementSpeed;
    private float currJumpForce;
    private bool isGrounded;
    private Vector3 inputMovement;
    private bool inputJump;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set default speed
        // 
        currMovementSpeed = DefaultMovementSpeed;
        currJumpForce = DefaultJumpForce;
    }
    
   /* void FixedUpdate()
    {
        // Apply Gravity
        velocity.y += Gravity;
        
        // Apply Movement
        Vector3 moveDirection = new Vector3(inputMovement.x, 0, inputMovement.y);
        
        // Apply Jump
        if (inputJump && isGrounded)
        {
            velocity.y += currJumpForce;
            inputJump = false;
        }
        
        // Reset vertical velocity when grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        
        playerMesh.transform.Translate(moveDirection * currMovementSpeed, Space.World);
        playerMesh.transform.Translate(velocity, Space.World);
    }*/

    // Update is called once per frame
    void Update()
    {
        // Apply Gravity
        velocity.y += Gravity;
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        print(isGrounded + " : " + velocity.y);
        
        // Reset vertical velocity when grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        
        // Apply Movement
        Vector3 moveDirection = new Vector3(inputMovement.x, 0, inputMovement.y);
        
        // Apply Jump
        if (inputJump && isGrounded)
        {
            velocity.y += currJumpForce;
            inputJump = false;
        }
        
        playerMesh.transform.Translate(moveDirection * currMovementSpeed, Space.World);
        playerMesh.transform.Translate(velocity, Space.World);
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector2>();
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inputJump = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (groundCheck)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
