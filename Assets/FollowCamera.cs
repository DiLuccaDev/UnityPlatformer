using System;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    [Header("Target Settings")] public Transform target;

    [Header("Camera Settings")] [SerializeField]
    private Vector3 targetOffset;

    [SerializeField] private float smoothSpeed = 1f;
    [SerializeField] private float lookAheadDistance = 2f;

    private Vector3 velocity = Vector3.zero;
    private Vector3 previousPosition;
    private Vector3 previousLookAtPoint;
    private Vector3 targetVelocity;

    private void Start() {
        if (target == null) return;
        previousPosition = target.position;
    }

    // Update is called once per frame
    void FixedUpdate() {

        if ((target.position.x - previousPosition.x) != 0) {
            targetVelocity = (target.position - previousPosition) / Time.deltaTime;
        }

        Vector3 lookAhead = new Vector3(Mathf.Sign(targetVelocity.x) * lookAheadDistance, (1 * lookAheadDistance)/2, 0f);
        Debug.DrawLine(target.position, target.position + lookAhead, Color.red);

        // Calculate the desired position with offset
        Vector3 goalPos = target.position + targetOffset + lookAhead;

        // Smoothly interpolate to the desired position
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothSpeed);
        
        // Always look at the target
        transform.LookAt(Vector3.Lerp(previousLookAtPoint, target.position + lookAhead, smoothSpeed));
        
        previousPosition = target.position;
        previousLookAtPoint = target.position + lookAhead;
    }
}