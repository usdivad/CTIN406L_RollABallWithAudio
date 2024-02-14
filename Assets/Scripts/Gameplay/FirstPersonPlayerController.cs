using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class FirstPersonPlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public Text countText;
	public Text winText;

	// Create public variables for look parameters
	public float lookSensitivity = 1f;
	public float lookTopClamp = 90f;
	public float lookBottomClamp = -90f;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	private int count;

	// Audio
	private PlayerAudioComponent playerAudioComponent;

	// Camera
	private GameObject mainCamera;
	private float lookRotationX = 0f;
	private float lookRotationY = 0f;

	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;

		// Run the SetCountText function to update the UI (see below)
		SetCountText ();

		// Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank
		winText.text = "";

		// Set player audio component
		playerAudioComponent = GetComponent<PlayerAudioComponent>();

		// Set camera
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

		// Hide cursor
		Cursor.visible = false;
	}

	// Each physics step..
	void FixedUpdate ()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		movement = moveVertical * mainCamera.transform.forward + moveHorizontal * mainCamera.transform.right;

		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
		// multiplying it by 'speed' - our public player speed that appears in the inspector
		rb.AddForce (movement * speed);

		// Update rolling audio based on velocity
		playerAudioComponent.UpdateRollingAudio(rb.velocity.magnitude);
	}

	// Each frame...
	void Update()
	{
		// Get look input
		float lookX = Input.GetAxis("Mouse X");
		float lookY = Input.GetAxis("Mouse Y");

		// Look: horizontal rotation
		lookRotationX += lookX * Time.deltaTime * lookSensitivity;

		// Look: vertical rotation
		lookRotationY -= lookY * Time.deltaTime * lookSensitivity;
		lookRotationY = Mathf.Clamp(lookRotationY, lookBottomClamp, lookTopClamp);

		// Set camera rotation and position
        mainCamera.transform.localEulerAngles = new Vector3(lookRotationY, lookRotationX, 0f);
		mainCamera.transform.position = transform.position + new Vector3(0f, 1f, 0f);
	}

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();

			// Play audio
			playerAudioComponent.PlayPickupAudio();
		}
	}

	// Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
	void SetCountText()
	{
		// Update the text field of our 'countText' variable
		countText.text = "Count: " + count.ToString ();

		// Check if our 'count' is equal to or exceeded 12
		if (count >= 12) 
		{
			// Set the text value of our 'winText'
			winText.text = "You Win!";

			// Play win audio
			playerAudioComponent.PlayWinAudio();
		}
	}
}