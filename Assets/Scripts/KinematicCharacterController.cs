using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KinematicCharacterController : MonoBehaviour
{

    [SerializeField] private float defaultMovementSpeed = 5f;
    private float currMovementSpeed;

    [SerializeField] private GameObject playerModel;

    // Start is called before the first frame update
    void Start()
    {
        currMovementSpeed = defaultMovementSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        playerModel.transform.Translate(context.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
