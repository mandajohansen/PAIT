using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressurePlateChecker : MonoBehaviour
{
    private  string Plate1Tag = "Plate1";
    private  string Plate2Tag = "Plate2";
    private  string Plate3Tag = "Plate3";



    public GameObject PlateOne;
    public GameObject PlateTwo;
    public GameObject PlateThree;

    public PressurePlateScript PlateOneScript;
    public PressurePlateScript PlateTwoScript;
    public PressurePlateScript PlateThreeScript;

    public float firstFadeWait;

    public float secondFadeWait;

    public GameObject fadeCanvas;

    private void Start()
    {
        PlateOne = GameObject.FindWithTag(Plate1Tag);
        PlateTwo = GameObject.FindWithTag(Plate2Tag);
        PlateThree = GameObject.FindWithTag(Plate3Tag);

        PlateOneScript = PlateOne.GetComponent<PressurePlateScript>();
        PlateTwoScript = PlateTwo.GetComponent<PressurePlateScript>();
        PlateThreeScript = PlateThree.GetComponent<PressurePlateScript>();
    }

    private void Update()
    {
        if (PlateOneScript.correctObjectOnPlate == true && PlateTwoScript.correctObjectOnPlate == true && PlateThreeScript.correctObjectOnPlate == true)
        {
            StartCoroutine(FadeToBlack());
        }
    }

    IEnumerator FadeToBlack()
    {
        yield return new WaitForSeconds(firstFadeWait);

        fadeCanvas.SetActive(true);

        yield return new WaitForSeconds(secondFadeWait);
        SceneManager.LoadScene(sceneName:"EscapeRoomOutro");




    }
}
