using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] Transform player;
    [SerializeField] float chaseRange = 20f;
    float targetSpace;
    bool isProvoked = false;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        targetSpace = Vector3.Distance(player.position, gameObject.transform.position);
        //In range to chase
        if (targetSpace <= chaseRange)
        {
            isProvoked = true;
        }
        if (isProvoked)
        {
            if(targetSpace > navMeshAgent.stoppingDistance) { ChaseTarget(); }
            if(targetSpace<= navMeshAgent.stoppingDistance) { AttackTarget(); }
        }

    }

    private void AttackTarget()
    {
        //Debug.Log($@"{name} attacking {player.name}");
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(player.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
