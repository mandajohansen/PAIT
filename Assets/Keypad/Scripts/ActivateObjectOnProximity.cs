using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectOnProximity : MonoBehaviour
{
    public GameObject targetObject; // The object you want to activate/deactivate
    public GameObject finger;
    public float activationDistance = 2f; // The distance threshold for activation

    void Update()
    {
        // Check the distance between this object and the targetObject
        float distance = Vector3.Distance(transform.position, finger.transform.position);

        // Activate or deactivate the targetObject based on the distance
        if (distance < activationDistance)
        {
            targetObject.SetActive(true); // Activate the object
        }
        else
        {
            targetObject.SetActive(false); // Deactivate the object
        }
    }
}
