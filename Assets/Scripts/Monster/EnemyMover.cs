using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform endPoint;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        endPoint = GameObject.FindGameObjectWithTag("EndPoint").transform;
        //agent.destination = endPoint.position;
    }

    private void Update()
    {
        agent.destination = endPoint.position;

        if (Vector3.Distance(transform.position, endPoint.position) < 0.3f)
            Destroy(gameObject);
    }
}
