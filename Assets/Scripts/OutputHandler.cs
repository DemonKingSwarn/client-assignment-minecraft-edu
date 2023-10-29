using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputHandler : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] CodeInterpreter codeInterpreter;
    [SerializeField] GateRemover gate;
    [SerializeField] GameObject interaction;
    [SerializeField] GameObject triggerCol;

    public void GreatSuccess()
    {
        gate.Remove();
        playerMovement.TogglePause();
        interaction.SetActive(false);
        playerMovement.questionsIndex += 1;
        triggerCol.SetActive(false);
    }
}
