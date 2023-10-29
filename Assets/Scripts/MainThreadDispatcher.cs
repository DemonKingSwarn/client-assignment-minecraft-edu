using System;
using UnityEngine;

public class MainThreadDispatcher : MonoBehaviour
{
    static MainThreadDispatcher _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void Enqueue(Action action)
    {
        _instance.gameObject.AddComponent<ActionExecutor>().Execute(action);
    }

    class ActionExecutor : MonoBehaviour
    {
        public void Execute(Action action)
        {
            action();
            Destroy(this);
        }
    }
}
