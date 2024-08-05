using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionListener : MonoBehaviour
{
    private void OnEnable()
    {
        DynamicActionManager.Instance.RegisterActionEvent("action2", () => {
            Debug.Log("CALLED Action 2");
        });

        DynamicActionManager.Instance.RegisterActionEvent("action3", () => {
            Debug.Log("CALLED Action 3");
        });
    }
    
}
