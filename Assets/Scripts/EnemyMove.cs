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
    [SerializeField] int damage = 1;
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
        else
        {
            GetComponent<Animator>().SetTrigger("idle");
        }
        if (isProvoked)
        {
            if(targetSpace < chaseRange) { ChaseTarget(); }
            if(targetSpace<= navMeshAgent.stoppingDistance)
            {
                GetComponent<Animator>().SetBool("attack", true);
            }
        }

    }

    private void AttackTarget()
    {
        var playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.HPDecrease(damage);
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack",false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(player.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
