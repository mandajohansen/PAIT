using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMovement : MonoBehaviour
{
    GameObject Lev_1;
    GameObject Lev_2;

    void Start()
    {
        Lev_1 = GameObject.FindWithTag("Lever_1");
        Lev_2 = GameObject.FindWithTag("Lever_2");
    }


    // Your original Switch method
    public void Switch()
    {
        if (Lev_1 != null & Lev_2 != null){
            Lev_1.SetActive(false);
            Debug.Log("Found OG");
            
            Lev_2.SetActive(true);
            Debug.Log("Found Copy");
        }
        else{
            Debug.LogError("haha nothing");
        }
      
    }

    // Call the Switch method when the UnityEvent is invoked
    public void OnSwitchEvent()
    {
        Switch();
    }
}

