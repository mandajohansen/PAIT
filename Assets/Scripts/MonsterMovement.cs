using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

    public float waitTime = 5f;
    public bool timeToWalk = false;
   //public float speed = 50f;
  // public float upSpeed = 0.0015f;
   
   // void FixedUpdate()
    //{
        //GetComponent<Rigidbody2D>().AddForce(Vector3.up * upSpeed);
    //}

    public float speed = 2;
    
    void Start()
    {
        StartCoroutine(WalkTime());
    }
    
    void Update()
{
    if (timeToWalk) 
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    // Moves the object forward at two units per second.
}

    IEnumerator WalkTime()
    {
        yield return new WaitForSeconds(waitTime);

        timeToWalk = true;
    }
}
