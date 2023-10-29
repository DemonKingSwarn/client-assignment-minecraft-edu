using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateRemover : MonoBehaviour
{
    [SerializeField] GameObject[] gates;

    public int gateIndex = 0;

    public void Remove()
    {
        Destroy(gates[gateIndex]);
        gateIndex += 1;
    }
}
