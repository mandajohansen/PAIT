using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyScriptforChest : MonoBehaviour
{
    GameObject mainChest;
    GameObject top;
    
    // Start is called before the first frame update
    void Start()
    {
        mainChest = GameObject.FindWithTag("main-chest");
        top = GameObject.FindWithTag("reinforced_wooden_chest_top");
    }

    // Update is called once per frame

    
    void Update()
    {
        /*if (mainChest != null)
        {
            
            if (top != null)
            {
                Debug.Log("Top object is not null.");
            }*/
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key2"))
        {
            top.transform.Rotate(0f, 0f, -55f);
            Debug.Log("trigger entered");
        }
    }
}

