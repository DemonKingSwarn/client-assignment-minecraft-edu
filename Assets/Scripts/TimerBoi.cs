using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerBoi : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;

    void Update()
    {
        float currentTime = Time.time;
        string timeString = currentTime.ToString("F2");
        timerText.text = timeString + "s";  
    }
}
