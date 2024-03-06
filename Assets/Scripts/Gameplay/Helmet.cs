using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet : MonoBehaviour
{
    [SerializeField]
    KeyCode equipKey = KeyCode.H;

    bool isEquipped = false;

    MeshRenderer meshRenderer;
    HelmetAudioComponent audioComponent;

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
        if (Input.GetKeyDown(equipKey))
        {
            if (!isEquipped)
            {
                Equip();
            }
            else
            {
                Unequip();
            }
        }
        //else
        //{
        //    if (isEquipped)
        //    {
        //        Unequip();
        //    }
        //}
    }

    void Equip()
    {
        meshRenderer.enabled = true;
        audioComponent.OnEquip();
        isEquipped = true;
        Debug.Log("Equipped helmet");
    }

    void Unequip()
    {
        meshRenderer.enabled = false;
        audioComponent.OnUnequip();
        isEquipped = false;
        Debug.Log("Unequipped helmet");
    }
}
