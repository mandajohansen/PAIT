using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    public GameObject chain; // Renamed to follow C# naming conventions

    // Start is called before the first frame update
    void Start()
    {
        // Use GameObject.FindWithTag to find the chain by its tag
        chain = GameObject.FindWithTag("chains");

        // Add a Rigidbody component if it doesn't exist
        Rigidbody chainRigidbody = chain.GetComponent<Rigidbody>();
        if (chainRigidbody == null)
        {
            chainRigidbody = chain.AddComponent<Rigidbody>();
            chainRigidbody.isKinematic = true; // Make it kinematic initially
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lever_2"))
        {
            // Enable gravity and remove kinematic to allow the chain to fall
            Rigidbody chainRigidbody = chain.GetComponent<Rigidbody>();
            chainRigidbody.isKinematic = false;
            chainRigidbody.useGravity = true;

            Debug.Log("Lever Done");
        }
    }
}
