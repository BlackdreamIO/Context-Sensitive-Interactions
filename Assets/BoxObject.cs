using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObject : MonoBehaviour
{

    public enum BoxObjectState {
        Push,
        Grab,
        Destory
    }
    [SerializeField] private float speed = 3f;
    [SerializeField] BoxObjectState currentState = BoxObjectState.Grab;
    private void Start()
    {
        
    }

    private void Update()
    {
        Debug.Log("Box Object Current State : " + currentState);
    }
    
    [ContextMenu("HandleGrab")] public void HandleGrab() => currentState = BoxObjectState.Grab;
    [ContextMenu("HandlePush")] public void HandlePush() => currentState = BoxObjectState.Push;
    [ContextMenu("HandleDestory")] public void HandleDestory() => currentState = BoxObjectState.Destory;
}
