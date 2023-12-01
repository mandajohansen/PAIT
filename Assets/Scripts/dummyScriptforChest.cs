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
        mainChest = GameObject.FindWithTag("main_chest");
        top = GameObject.FindWithTag("reinforced_wooden_chest_top");
    }

    // Update is called once per frame

    
    void Update()
    {
        Debug.Log("Update method is called.");
        if (mainChest != null)
        {
            if (top != null)
            {
                Debug.Log("Top object is not null.");
                GetKeyPressed(top);
            }
        
    }
    
    }

    void GetKeyPressed(GameObject key)
    {
        Debug.Log("GetKeyPressed method is called.");

        if (Input.GetKey(KeyCode.P))
        {
            Debug.Log("P key is pressed.");
            key.transform.Rotate(0f, 0f, -55f);
        }

        if (Input.GetKey(KeyCode.U))
        {
            Debug.Log("U key is pressed.");
            key.transform.Rotate(0f, 0f, 55f);
        }
    }
}
