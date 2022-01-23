using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DarkWorldManager.Instance.ActivateDarkWorld(!DarkWorldManager.Instance.IsActive());
        }
    }

    private void FixedUpdate()
    {
        
    }
}
