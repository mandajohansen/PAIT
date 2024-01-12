using UnityEngine;

public class LighterLight : MonoBehaviour
{
    public GameObject lightSource;
    public GameObject candleLight;
    public GameObject candleLightLight; // reference to the visual effect of the candle light
    public float movementThreshold = 5f; // speed value for light source activation
    public float detectionRange = 2f; // range for detecting the candles
    private bool isLightSourceActive = false; 
    private Vector3 lastPosition; // last recorded position for movement calculation
    private float timeSinceLastMovement = 0f; // timer for tracking inactivity
    private float inactivityThreshold = 10f; // time in seconds for inactivity detection
    public AudioClip lighterAudio; 

    void Start()
    {
        // initializes last position
        lastPosition = transform.position;
    }

    void Update()
    {
        // calculate objects movement speed
        Vector3 currentPosition = transform.position;
        float speed = Mathf.Abs((currentPosition - lastPosition).magnitude) / Time.deltaTime;

        // toggles light source on movementThreshold movement
        if (speed > movementThreshold)
        {
            ToggleLightSource();
            timeSinceLastMovement = 0f;
        }

        // updates last position and inactivity timer
        lastPosition = currentPosition;
        timeSinceLastMovement += Time.deltaTime;

        // deactivates light source after amount of seconds
        if (timeSinceLastMovement > inactivityThreshold && isLightSourceActive)
        {
            ToggleLightSource();
        }

        // detects nearby candle collider
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

        // activates candle light if conditions are met
        if (isLightSourceActive && isCandleColliderInRange)
        {
            ActivateCandleLight();
        }
    }

    void ToggleLightSource()
    {
        // toggles the light source and play lighter sound
        isLightSourceActive = !isLightSourceActive;
        lightSource.SetActive(isLightSourceActive);

        AudioSource lighterSound = this.gameObject.GetComponent<AudioSource>();
        lighterSound.PlayOneShot(lighterAudio);
    }

    void ActivateCandleLight()
    {
        // activates candle light and initiate object movement of candle lights.
        // for the Reveal script to work, the light object had to already be in the scene, and then moved down.
        if (candleLight != null)
        {
            candleLight.SetActive(true);
            MoveObjectDown();
        }
    }

    private bool hasTeleported = false; // tracks if the object has been moved

    void MoveObjectDown()
    {
        // moves the candle light object downwards once
        if (candleLightLight != null && candleLightLight.CompareTag("CandleLightLight") && !hasTeleported)
        {
            Vector3 newPosition = candleLightLight.transform.position;
            newPosition.y -= 2.8f;
            candleLightLight.transform.position = newPosition;

            hasTeleported = true;
        }
    }
}

