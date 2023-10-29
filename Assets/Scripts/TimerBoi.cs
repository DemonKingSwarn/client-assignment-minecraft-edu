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
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = "Time: " + timeString;  
    }
}
