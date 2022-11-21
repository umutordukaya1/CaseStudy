using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    private ObjectPooling objectPooling;
    private Spawner spawner;
    public float speed,distance;
    public static AIMovement Instance;
    public Transform[] followPoint;
    public int pointCount;
    public NavMeshAgent agent;
    GameManager gameManager;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        spawner = Spawner.instance;
        objectPooling = ObjectPooling.Instance;
        agent = GetComponent<NavMeshAgent>();
        gameManager = GameManager.Instance;
    }

    void Update()
    {
       
        AIMove();
    }

    void AIMove()
    {

        agent.SetDestination(followPoint[pointCount].position);
        distance = Vector3.Distance(transform.position, followPoint[pointCount].position);

        if (distance<1)
        {
            pointCount++;
        }
        if (Physics.Raycast(transform.position,transform.forward,-5))
        {
            agent.speed = 0;
        }
        else
        {
            agent.speed = speed;
        }
        if (pointCount==followPoint.Length)
        {
            pointCount = 0;
        }
        if (gameManager.timerOn==false)
        {
            agent.speed = 0;
        }
        else
        {
            agent.speed = speed;
        }
            //transform.position = Vector3.MoveTowards(transform.position, newposition.position, speed * Time.deltaTime);
          // transform.eulerAngles = newposition.position;
        
       
        
           
        
    }
}
