using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int fps = 60;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Application.targetFrameRate = fps;
        Application.runInBackground = false;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(player.transform.position.y <= 9.02f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
