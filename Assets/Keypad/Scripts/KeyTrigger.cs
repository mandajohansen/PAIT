using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyTrigger : MonoBehaviour
{

    public GameObject drawerToInteract;
    // Start is called before the first frame update
    void Start()
    {
        drawerToInteract = GameObject.FindWithTag("Drawer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            // Key entered the trigger zone
            //drawerToInteract.GetComponent<XRGrabInteractable>().enabled = true;
            //drawerToInteract.GetComponent<Rigidbody>().isKinematic = false;
            OpenCabinet();

            Debug.Log("Key inserted!");
            //Destroy(this.gameObject);
        }
    }

    void OpenCabinet()
    {
        drawerToInteract.GetComponent<XRGrabInteractable>().enabled = true;
        drawerToInteract.GetComponent<Rigidbody>().isKinematic = false;
    }
}
