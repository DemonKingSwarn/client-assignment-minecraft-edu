using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TMP_Text totalTime;
    [SerializeField] TimerBoi timer;
    [SerializeField] GameObject oldTimer;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
            oldTimer.SetActive(false);
            totalTime.text = "Time Taken: " + timer.timeString;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
