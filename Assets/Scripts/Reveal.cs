using UnityEngine;

/// <summary>
/// Script that changes the material properties based on the position, direction and angle 
/// of a spotlight. This is for the numbers that must be revealed on the wall with the Lighter.
/// </summary>

[ExecuteInEditMode]
public class Reveal : MonoBehaviour
{
    [SerializeField] Material Mat;
    [SerializeField] Light SpotLight;

    void Update()
    {
        Mat.SetVector("MyLightPosition", SpotLight.transform.position);
        Mat.SetVector("MyLightDirection", -SpotLight.transform.forward);
        Mat.SetFloat("MyLightAngle", SpotLight.spotAngle);
    }//Update() end
}//class end