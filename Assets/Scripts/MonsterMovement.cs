using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

    public float waitTime = 5f;
    public bool timeToWalk = false;
  

    public float speed = 2;
    
   /* void Start()
    {
        StartCoroutine(WalkTime());
    }
    */
    void Update()
{
   // if (timeToWalk) 
    //{
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
   // }

}

    /*IEnumerator WalkTime()
    {
        yield return new WaitForSeconds(waitTime);

        timeToWalk = true;
    }*/
}
