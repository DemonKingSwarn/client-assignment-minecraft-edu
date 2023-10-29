using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    [SerializeField] GameObject interactionText;
    [SerializeField] PlayerMovement playerMovement;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            interactionText.SetActive(true);
            playerMovement.escapePressedThisFrame = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            interactionText.SetActive(false);
        }
    }
}
