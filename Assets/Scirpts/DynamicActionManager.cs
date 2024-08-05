using System;
using System.Collections.Generic;
using UnityEngine;

public class DynamicActionManager : MonoBehaviour
{
    public static DynamicActionManager Instance;

    private Dictionary<string, Action> actions;
    private Dictionary<string, Action> actionEvents;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeActions();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeActions()
    {
        actions = new Dictionary<string, Action>
        {
            { "action1", () => ExecuteAndInvoke("action1") },
            { "action2", () => ExecuteAndInvoke("action2") },
            { "action3", () => ExecuteAndInvoke("action3") }
        };

        actionEvents = new Dictionary<string, Action>();
    }

    public void ExecuteAction(string actionName)
    {
        if (actions.TryGetValue(actionName, out Action action))
        {
            action.Invoke();
        }
        else
        {
            Debug.LogWarning($"Action {actionName} not found.");
        }
    }

    public void RegisterActionEvent(string actionName, Action listener)
    {
        if (!actionEvents.ContainsKey(actionName))
        {
            actionEvents[actionName] = null;
        }
        actionEvents[actionName] += listener;
    }

    public void UnregisterActionEvent(string actionName, Action listener)
    {
        if (actionEvents.ContainsKey(actionName))
        {
            actionEvents[actionName] -= listener;
        }
    }

    private void ExecuteAndInvoke(string actionName)
    {
        Debug.Log($"Executing {actionName}");
        if (actionEvents.TryGetValue(actionName, out Action eventAction))
        {
            eventAction?.Invoke();
        }
    }
}
