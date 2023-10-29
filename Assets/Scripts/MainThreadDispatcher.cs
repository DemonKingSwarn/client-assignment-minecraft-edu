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
        private Action action;
        private bool actionExecuted = false;

        public void Execute(Action action)
        {
            this.action = action;
        }

        void Update()
        {
            if (action != null && !actionExecuted)
            {
                action();
                actionExecuted = true;
                Destroy(this);
            }
        }
    }
}
