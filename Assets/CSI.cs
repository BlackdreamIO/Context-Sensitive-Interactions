using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace ContextSensitiveSystem.CSI
{
    public class CSI : MonoBehaviour
    {
        public List<ContextSituationsEvent> events = new List<ContextSituationsEvent>();
        private void Start()
        {

        }

        private void Update()
        {

        }
        public void TriggerEvent(string eventName)
        {
            foreach (var customEvent in events)
            {
                if (customEvent.eventName == eventName)
                {
                    customEvent.unityEvent.Invoke();
                    return;
                }
            }
            Debug.LogWarning("No event found with name: " + eventName);
        }
    }   
}

[Serializable]
public class ContextSituationsEvent
{
    public string eventName;
    public UnityEvent unityEvent;
}
