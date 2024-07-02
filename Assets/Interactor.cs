using System.Collections;
using System.Collections.Generic;
using ContextSensitiveSystem.CSO;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform origin = null;
    [SerializeField] private float range = 40f;

    private void Start()
    {
        origin.GetComponent<Camera>();
    }

    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(origin.transform.position, origin.forward, out hit, range))
        {
            if(hit.collider.GetComponent<CSO>())
            {
                var cso = hit.collider.GetComponent<CSO>();
                
            }
        }
    }
}
