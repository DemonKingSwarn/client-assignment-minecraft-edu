using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    [SerializeField] GameObject interactionText;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            interactionText.SetActive(true);
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
