using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Equippable helmet **/
public class Helmet : MonoBehaviour
{
    [SerializeField]
    KeyCode equipKey = KeyCode.H; // Key to toggle equip/unequip

    bool isEquipped = false; // Whether helmet is equipped

    MeshRenderer meshRenderer; // Mesh renderer for the helmet
    HelmetAudioComponent audioComponent; // Helmet audio component

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        audioComponent = GetComponent<HelmetAudioComponent>();

        Unequip();
    }

    // Update is called once per frame
    void Update()
    {
        // Equip when key is held down, unequip when key is released
        if (Input.GetKey(equipKey))
        {
            if (!isEquipped)
            {
                Equip();
            }
        }
        else
        {
            if (isEquipped)
            {
                Unequip();
            }
        }
    }

    // Equip the helmet
    void Equip()
    {
        meshRenderer.enabled = true;
        audioComponent.OnEquip();
        isEquipped = true;
        Debug.Log("Equipped helmet");
    }

    // Unequip the helmet
    void Unequip()
    {
        meshRenderer.enabled = false;
        audioComponent.OnUnequip();
        isEquipped = false;
        Debug.Log("Unequipped helmet");
    }
}
