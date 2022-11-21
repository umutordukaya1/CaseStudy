using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReurn : MonoBehaviour
{
    private ObjectPooling objectPooling;
    void Start()
    {
        objectPooling = ObjectPooling.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        if (objectPooling!=null)
        {
            objectPooling.ReturnObject(this.gameObject);
        }
    }
}
