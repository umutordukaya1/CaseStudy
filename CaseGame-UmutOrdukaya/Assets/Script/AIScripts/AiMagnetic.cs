using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMagnetic : MonoBehaviour
{
    [SerializeField] float magneticForce = default;
    [SerializeField] Color goldColor = default;
    public static event Action aiCubeEntered;
    private ObjectPooling objectPooling;

    //public static AiMagnetic Instance;
    //private void Awake()
    //{
    //    Instance = this;
    //}
    private void Start()
    {
        objectPooling = ObjectPooling.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            other.gameObject.layer = 9;
            other.attachedRigidbody.velocity = (transform.position - other.transform.position) * magneticForce;
            aiCubeEntered?.Invoke();
            //AIMovement.Instance.isControl = false;

        }
        if (other.gameObject.layer == 9)
        {
            other.gameObject.layer = 8;
            objectPooling.ReturnObject(other.gameObject);
        }

    }
}
