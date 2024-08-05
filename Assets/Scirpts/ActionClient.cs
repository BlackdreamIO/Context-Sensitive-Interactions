using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionClient : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            DynamicActionManager.Instance.ExecuteAction("ac1");
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            DynamicActionManager.Instance.ExecuteAction("ac1");
        }
    }
}
