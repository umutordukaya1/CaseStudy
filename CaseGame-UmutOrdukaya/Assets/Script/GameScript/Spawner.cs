using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float timeToSpawn = 5f;
    private float timeSinceSpawn;
    private ObjectPooling objectPooling;
    public Transform SpawnPoint;
    public static Spawner instance;
    private void Awake()
    {
        instance= this;
    }
    void Start()
    {
        objectPooling=ObjectPooling.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn >= timeToSpawn)
        {
            GameObject newObject=objectPooling.GetObject();
            newObject.transform.position= this.transform.position;
            newObject.transform.parent = SpawnPoint;
            timeSinceSpawn= 0f;
        }
    }
}
