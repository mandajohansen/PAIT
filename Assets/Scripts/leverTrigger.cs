using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    GameObject chain;
    Rigidbody chainRigidbody;
    public AudioSource playSound;
    public bool hasTriggered;

    // Start is called before the first frame update
    void Start()
    {
        // Use GameObject.FindWithTag to find the chain by its tag
        chain = GameObject.FindWithTag("chains");
        chain.GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if (chain != null)
        {
            chainRigidbody = chain.GetComponent<Rigidbody>();
            Debug.Log("Chain found.");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lever_2"))
        {
            if(!hasTriggered)
            { 
            chainRigidbody.isKinematic = false;
            chainRigidbody.useGravity = true;
            playSound.Play();
            hasTriggered = true;
            Debug.Log("Lever Done");
            }
    }
    }
}
