using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour {
    [Header("Movement Settings")] public float DefaultMovementSpeed = 1f;
    public float DefaultJumpForce = 1f;
    public float Gravity = -9.81f;
    //jump


    [Header("Ground Check Settings")] [SerializeField]
    private Transform groundCheck;

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

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        // Set default speed
        currMovementSpeed = DefaultMovementSpeed;
        currJumpForce = DefaultJumpForce;
    }

    void Update() {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // Reset vertical velocity when grounded
        if (isGrounded && velocity.y < 0) {
            velocity.y = 0f;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        // Apply Gravity
        velocity.y += Gravity;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer | wallLayer);

        // Apply Jump
        if (inputJump && isGrounded) {
            velocity.y += currJumpForce;
            inputJump = false;
        }

        // Reset vertical velocity when grounded
        if (isGrounded && velocity.y < 0) {
            velocity.y = 0f;
        }

        // Apply Movement
        Vector3 moveDirection = new Vector3(
            inputMovement.x * currMovementSpeed,
            velocity.y * currJumpForce,
            0);

        playerMesh.transform.Translate(moveDirection, Space.World);

        // Rotate to face movement
        if (moveDirection.x != 0)
            playerMesh.rotation = Quaternion.LookRotation(new Vector3(inputMovement.x, 0, 0), Vector3.up);
    }

    public void OnMove(InputAction.CallbackContext context) {
        inputMovement = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context) {
        if (context.performed) {
            inputJump = true;
        }
    }

    private void OnDrawGizmos() {
        if (groundCheck) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}