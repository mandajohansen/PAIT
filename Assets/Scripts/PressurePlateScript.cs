using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    public string correctTag = "YourCorrectTag";  // Assign the correct tag from the Inspector
    public string incorrectTagOne = "YourIncorrectTagOne";  // Assign the first incorrect tag from the Inspector
    public string incorrectTagTwo = "YourIncorrectTagTwo";  // Assign the second incorrect tag from the Inspector
    public GameObject checker;  // Assign the checker object from the Inspector
    public Material correctMaterial;  // Assign the material for the correct tag from the Inspector
    public Material incorrectMaterial; 
    
    public Material defaultMaterial;  // Assign the material for incorrect tags from the Inspector

    public bool correctObjectOnPlate;

    private bool isObjectOnPlate = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(correctTag))
        {
            // Change the material to the correct material
            ChangeCheckerMaterial(correctMaterial);

            correctObjectOnPlate = true;
        }
        else if (other.CompareTag(incorrectTagOne) || other.CompareTag(incorrectTagTwo))
        {
            // Change the material to the incorrect material
            ChangeCheckerMaterial(incorrectMaterial);
            correctObjectOnPlate = false;
        }

        isObjectOnPlate = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (isObjectOnPlate)
        {
            // Reset the material to its original state when the object leaves the trigger
            Renderer checkerRenderer = checker.GetComponent<Renderer>();

            // Change the material of the checker
            checkerRenderer.material = defaultMaterial;
            correctObjectOnPlate = false;
        }

        isObjectOnPlate = false;
    }

    private void ChangeCheckerMaterial(Material newMaterial)
    {
        // Check if the checker object is assigned
        if (checker != null)
        {
            // Assuming the checker has a Renderer component
            Renderer checkerRenderer = checker.GetComponent<Renderer>();

            // Change the material of the checker
            checkerRenderer.material = newMaterial;
        }
        else
        {
            Debug.LogError("Checker object is not assigned!");
        }
    }

    private void ResetCheckerMaterial()
    {
        // Reset the material to its original state
        ChangeCheckerMaterial (defaultMaterial);
    }
}
