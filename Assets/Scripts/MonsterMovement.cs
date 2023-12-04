using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterMovement : MonoBehaviour
{

    public float waitTime = 5f;
    public bool timeToWalk = false;
    public GameObject bloodPanel;

    public AudioClip sliceSound;
    public AudioSource playerAudioSource;
  

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

    public IEnumerator SceneSwitch()
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("SceneSwitch Time");

        SceneManager.LoadScene(sceneName: "EscapeRoomFinish");

    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SceneSwitch());
            bloodPanel.SetActive(true);
            playerAudioSource.PlayOneShot(sliceSound);
            
        }
    }
}
