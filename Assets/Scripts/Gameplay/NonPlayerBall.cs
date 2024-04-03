using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class NonPlayerBall : MonoBehaviour
{
    // ----------------
    // Create public variables for player speed, and for the Text UI game objects

    [SerializeField]
    float speed;

    [SerializeField]
    Text countText;

    [SerializeField]
    Text winText;
    
    [SerializeField]
    int countMax = 12;

    // ----------------
    // Variables for music-driven behavior

    // Pickups, which will be toggled on/off at the start of each bar
    [SerializeField]
    GameObject[] pickups;

    // Scale at which to enlarge the ball, which will occur on each beat
    [SerializeField]
    float enlargeScale = 1.5f;

    // How fast to shrink the ball back to a scale of 1
    [SerializeField]
    float shrinkDuration = 0.2f; // In seconds

    // ----------------
    // Create private references to the rigidbody component on the ball, and the count of pick up objects picked up so far
    Rigidbody rb;
    int count;

    // How much time has elapsed for our current shrink operation
    float shrinkTimeElapsed = 0f;

    // Audio
    BallAudioComponent ballAudioComponent;

    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();

        // Set the count to zero 
        count = 0;

        // Run the SetCountText function to update the UI (see below)
        SetCountText();

        // Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winText.text = "";

        // Set player audio component
        ballAudioComponent = GetComponent<BallAudioComponent>();
    }

    // Each physics step..
    void FixedUpdate()
    {
        // Update rolling audio based on velocity
        ballAudioComponent.UpdateRollingAudio(rb.velocity.magnitude);
    }

    // Each frame...
    void Update()
    {
        // Shrink ball back down to normal size
        if (shrinkTimeElapsed < shrinkDuration)
        {
            float shrinkPercentage = Mathf.Clamp01(shrinkTimeElapsed / shrinkDuration);
            float scale = Mathf.Lerp(enlargeScale, 1f, shrinkPercentage);
            transform.localScale = Vector3.one * scale;
            shrinkTimeElapsed += Time.deltaTime;
        }
    }

    // When this game object intersects a collider with 'is trigger' checked, 
    // store a reference to that collider in a variable named 'other'..
    void OnTriggerEnter(Collider other)
    {
        // ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // Make the other game object (the pick up) inactive, to make it disappear
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);

            // Add one to the score variable 'count'
            count = count + 1;

            // Run the 'SetCountText()' function (see below)
            SetCountText();

            // Play audio
            ballAudioComponent.PlayPickupAudio();
        }
    }

    // Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
    void SetCountText()
    {
        // Update the text field of our 'countText' variable
        countText.text = "Count: " + count.ToString();

        // Check if our 'count' is equal to or exceeded countMax
        if (count >= countMax)
        {
            // Set the text value of our 'winText'
            winText.text = "You Win!";

            // Play win audio
            ballAudioComponent.PlayWinAudio();
        }
    }

    // ----------------

    // Toggle pickups on/off
    public void TogglePickups()
    {
        foreach (GameObject pickup in pickups)
        {
            if (pickup != null)
            {
                pickup.SetActive(!pickup.activeSelf);
            }
        }
    }

    // Enlarge the ball
    public void Enlarge()
    {
        transform.localScale = Vector3.one * enlargeScale;
        shrinkTimeElapsed = 0f;
    }
}