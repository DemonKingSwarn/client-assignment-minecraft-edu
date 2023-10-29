using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputHandler : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameObject gateObject;

    public void GreatSuccess()
    {
        Destroy(gateObject);
        playerMovement.TogglePause();
    }
}
