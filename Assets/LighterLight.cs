using UnityEngine;

public class LighterLight : MonoBehaviour
{
    public GameObject lightSource;
    public float movementThreshold = 5f; // Adjust this threshold as needed
    private bool isLightSourceActive = false;
    private Vector3 lastPosition;
    private float timeSinceLastMovement = 0f;
    private float inactivityThreshold = 10f; // Adjust this threshold as needed

    void Start()
    {
        // Store the initial position for velocity calculation
        lastPosition = transform.position;
    }

    void Update()
    {
        // Calculate the current velocity
        Vector3 currentPosition = transform.position;
        float speed = Mathf.Abs((currentPosition - lastPosition).magnitude) / Time.deltaTime;

        // Check for quick movement
        if (speed > movementThreshold)
        {
            ToggleLightSource();
            timeSinceLastMovement = 0f; // Reset the timer
        }

        // Update the last position for the next frame
        lastPosition = currentPosition;

        // Update the timer
        timeSinceLastMovement += Time.deltaTime;

        // Check for inactivity and deactivate the light source
        if (timeSinceLastMovement > inactivityThreshold && isLightSourceActive)
        {
            ToggleLightSource();
        }
    }

    void ToggleLightSource()
    {
        isLightSourceActive = !isLightSourceActive;
        lightSource.SetActive(isLightSourceActive);
    }
}
