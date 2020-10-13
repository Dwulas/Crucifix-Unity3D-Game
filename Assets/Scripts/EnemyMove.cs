using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform player;
    public float awareAI = 10f;
    public float AIMoveSpeed;
    public Transform[] navPoint;
    public UnityEngine.AI.NavMeshAgent agent;
    public int desPoint = 0;


    void Start()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }


    void Update()
    {

        if (agent.remainingDistance < 0.5f)
            GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if(navPoint.Length == 0)
            return;
        {
            agent.destination = navPoint[desPoint].position;
            desPoint = (desPoint + 1) % navPoint.Length;
        }
    }
}
