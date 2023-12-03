using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadChecker : MonoBehaviour
{
    public GameObject keypadDoor;
    public GameObject keypadTable;

    public GameObject targetObject;
    public GameObject finger;

    public float activationDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float tableDistance = Vector3.Distance(keypadTable.transform.position, finger.transform.position);
        float doorDistance = Vector3.Distance(keypadDoor.transform.position, finger.transform.position);

        if (tableDistance < activationDistance || doorDistance < activationDistance)
        {
            targetObject.SetActive(true); // Activate the object
        }
        else
        {
            targetObject.SetActive(false); // Deactivate the object
        }


    }
}
