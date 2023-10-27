using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] int fps = 60;

    void Awake()
    {
        Application.targetFrameRate = fps;
        Application.runInBackground = false;
    }
    
}
