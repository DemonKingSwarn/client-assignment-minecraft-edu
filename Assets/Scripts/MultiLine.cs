using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiLine : MonoBehaviour
{
    [SerializeField] TMP_InputField[] inputFields;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <= inputFields.Length; i++)
        {
            inputFields[i].lineType = TMP_InputField.LineType.MultiLineNewline;
        }
    }
}
