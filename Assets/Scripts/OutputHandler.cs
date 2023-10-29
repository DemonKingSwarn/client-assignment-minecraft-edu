using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputHandler : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameObject gateObject;
    [SerializeField] GameObject interaction;

    public void GreatSuccess()
    {
        Destroy(gateObject);
        playerMovement.TogglePause();
        interaction.SetActive(false);
    }
}
