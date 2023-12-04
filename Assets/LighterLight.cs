using UnityEngine;

public class LighterLight : MonoBehaviour
{
    public GameObject lightSource;
    public GameObject candleLight;
    public GameObject candleLightLight; // Reference to the CandleLightLight object
    public float movementThreshold = 5f;
    public float detectionRange = 2f;
    private bool isLightSourceActive = false;
    private Vector3 lastPosition;
    private float timeSinceLastMovement = 0f;
    private float inactivityThreshold = 10f;
    public AudioClip lighterAudio;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        float speed = Mathf.Abs((currentPosition - lastPosition).magnitude) / Time.deltaTime;

        if (speed > movementThreshold)
        {
            ToggleLightSource();
            timeSinceLastMovement = 0f;
        }

        lastPosition = currentPosition;
        timeSinceLastMovement += Time.deltaTime;

        if (timeSinceLastMovement > inactivityThreshold && isLightSourceActive)
        {
            ToggleLightSource();
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRange);
        bool isCandleColliderInRange = false;

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("CandleCollider"))
            {
                isCandleColliderInRange = true;
                break;
            }
        }

        if (isLightSourceActive && isCandleColliderInRange)
        {
            ActivateCandleLight();
        }
    }

    void ToggleLightSource()
    {
        isLightSourceActive = !isLightSourceActive;
        lightSource.SetActive(isLightSourceActive);

        AudioSource lighterSound = this.gameObject.GetComponent<AudioSource>();

        lighterSound.PlayOneShot(lighterAudio);
    }

    void ActivateCandleLight()
    {
        if (candleLight != null)
        {
            candleLight.SetActive(true);
            MoveObjectDown();
        }
    }

    private bool hasTeleported = false; // New variable to track whether teleportation has occurred

    void MoveObjectDown()
    {
        if (candleLightLight != null && candleLightLight.CompareTag("CandleLightLight") && !hasTeleported)
        {

            // Teleport the object to a new position along the Z-axis
            Vector3 newPosition = candleLightLight.transform.position;
            newPosition.y -= 2.8f;
            candleLightLight.transform.position = newPosition;

            // Set the flag to indicate that teleportation has occurred
            hasTeleported = true;
        }
    }


}
