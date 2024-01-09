using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    // Define Variables
    GameObject chain;
    Rigidbody chainRigidbody;
    public AudioSource playSound;
    public bool hasTriggered;

    // Start is called before the first frame update
    void Start()
    {
        // Use GameObject.FindWithTag to find the chain by its tag
        chain = GameObject.FindWithTag("chains");
        // Get the Chains Rigid Body
        chain.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // If Chain is not null, i.e it is found, then set the chainRigidbody variable to the chain's rigidbody
        if (chain != null)
        {
            chainRigidbody = chain.GetComponent<Rigidbody>();
            Debug.Log("Chain found.");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // If the collided object is a lever 2 then:
        if (other.CompareTag("Lever_2"))
        {

            if (!hasTriggered)
            {
                // If it has not triggered then:
                // Set the chainRigidbody's isKinematic to false, so that it can move
                // Set the chainRigidbody's useGravity to true, so that it can fall into position
                // Play the sound
                // Set hasTriggered to true
                // Log "Lever Done"

                chainRigidbody.isKinematic = false;
                chainRigidbody.useGravity = true;
                playSound.Play();
                hasTriggered = true;
                Debug.Log("Lever Done");
            }
        }
    }
}
