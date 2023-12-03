using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            //Debug.Log("Correct Placement!");
        }
    }
}
