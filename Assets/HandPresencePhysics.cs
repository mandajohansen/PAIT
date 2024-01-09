using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    public Renderer nonPhysicalHand;
    public float showNonPhysicalHandDistance = 0.05f;

    private Collider[] handColliders;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // adds all colliders on hand to array of colliders
        handColliders = GetComponentsInChildren<Collider>();
    }

    public void EnableHandCollider()
    {
        // enables colliders for each item in array
        foreach (var item in handColliders)
        {
            item.enabled = true;
        }

    }

    // Adds delay to avoid collision complications on release. Is assigned on XR Direct Interactor.
    public void EnableHandColliderDelay(float delay)
    {
        Invoke("EnableHandCollider", delay);
    }

    public void DisableHandCollider()
    {
        // disables colliders for each item in array. Is assigned on XR Direct Interactor.

        foreach (var item in handColliders)
        {
            item.enabled = false;
        }
    }

        private void Update()
    {

        // Logic to determine the distance between physical and non-physical hand. 
        float distance = Vector3.Distance(transform.position, target.position);

        // If gap is larger than our thresholds, then the non-physical hand is made visible
        if (distance > showNonPhysicalHandDistance)
        {
            nonPhysicalHand.enabled = true;
        }
        else 
            nonPhysicalHand.enabled = false;
        
        // This works due to the physical hand being restricted in its range of movement by other objects,
        // creating a gap between it and the target hand.
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Updates position to target position using rigidbody
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime; 


        // Gets the difference in rotation between this object and target as quaternion
        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);

        // Gets the difference in rotation between this object and target in degrees
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);
        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        // AngularVelocity measured angles in radians. Therefore this converts the rotation difference in degrees to radians.
        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}
