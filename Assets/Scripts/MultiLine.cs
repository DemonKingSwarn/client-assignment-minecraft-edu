using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiLine : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField.lineType = TMP_InputField.LineType.MultiLineNewline;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
