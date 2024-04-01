using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    // The tag to use for checking the player
    [SerializeField]
    string playerTag = "Player";

    // The key that will cause an interact
    [SerializeField]
    KeyCode interactKey = KeyCode.E;

    // Radius within which interactions are enabled
    [SerializeField]
    float interactRadius = 3f;

    // Example event to post on interact
    [SerializeField]
    AK.Wwise.Event exampleInteractEvent;

    bool isInteractionEnabled = false;
    SphereCollider interactTrigger;

    GameObject canvasGameObject;
    Canvas canvas;
    GameObject textGameObject;
    Text text;

    // ----------------------------------------------------------------
    // EDIT THIS METHOD TO DEFINE YOUR OWN AUDIO FUNCTIONALITY:

    // Method called on player interaction
    public void Interact()
    {
        Debug.Log("Interact! Edit the Interactable.Interact() method to add your own functionality");

        // This is just an example event posting on interact
        exampleInteractEvent.Post(this.gameObject);

        // Add your custom audio functionality here.
        //
        // e.g.
        // ```
        // someEvent.Post(this.gameObject);
        // someRtpc.SetGlobalValue(0.5f);
        // someSwitch.SetValue(this.gameObject);
        // someState.SetValue();
        // ```
        //
        // It may be useful to reference other scripts in the Scripts/Audio folder.
    }

    // ----------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        // Trigger
        this.gameObject.AddComponent<SphereCollider>();
        interactTrigger = GetComponent<SphereCollider>();
        interactTrigger.radius = interactRadius;
        interactTrigger.isTrigger = true;

        // Canvas
        canvas = GetComponent<Canvas>();

        if (canvas == null)
        {
            canvasGameObject = new GameObject();
            canvasGameObject.name = "InteractableCanvas";

            canvasGameObject.AddComponent<Canvas>();
            canvas = canvasGameObject.GetComponent<Canvas>();

        }

        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.AddComponent<CanvasScaler>();
        canvas.AddComponent<GraphicRaycaster>();

        // Text
        textGameObject = new GameObject();
        textGameObject.transform.parent = canvasGameObject.transform;
        textGameObject.AddComponent<Text>();
        text = textGameObject.GetComponent<Text>();

        RectTransform rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = Vector3.zero;
        rectTransform.sizeDelta = new Vector2(Screen.width / 2f, Screen.height / 2f);

        text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        text.fontSize = 48;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteractionEnabled)
        {
            text.text = string.Format("Press {0} to interact", interactKey.ToString());

            if (Input.GetKeyDown(interactKey))
            {
                Interact();
            }
        }
        else
        {
            text.text = "";
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isInteractionEnabled = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            isInteractionEnabled = false;
        }
    }
}
