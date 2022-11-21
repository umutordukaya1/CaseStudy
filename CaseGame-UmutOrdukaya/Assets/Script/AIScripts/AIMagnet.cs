using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMagnet : MonoBehaviour
{
    [SerializeField] public float magneticForce = default;
    public static AIMagnet instance;
    private void Awake()
    {
        instance= this;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            other.attachedRigidbody.AddForce((transform.position - other.transform.position) * magneticForce);
        }
     
    }
}
