using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    public Queue<GameObject> objectPool = new Queue<GameObject>();
    [SerializeField]
    private int poolStartSize = 5;
    private Spawner spawner;
    #region Singleton
    public static ObjectPooling Instance;
    private void Awake()
    {
        Instance = this;
    }

    #endregion
    void Start()
    {
        spawner = Spawner.instance;
        for (int i = 0; i < poolStartSize; i++)
        {
            GameObject gameObject = Instantiate(prefab);
            objectPool.Enqueue(gameObject);
            gameObject.SetActive(false);
            gameObject.transform.parent = spawner.SpawnPoint;

        }

    }
    public GameObject GetObject()
    {
        if (objectPool.Count > 0)
        {
            GameObject obj = objectPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject obj=Instantiate(prefab);
            return obj;
        }
    }
    public void ReturnObject(GameObject gameObject)
    {
        objectPool.Enqueue(gameObject);
        gameObject.SetActive(false);

    }
    
}
