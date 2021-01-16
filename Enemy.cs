using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float lookRadius = 10;
    Transform target;
    NavMeshAgent agent;
    public Transform attackpoint;
    public LayerMask player;
    private bool canAttack=true;

    void Start()
    {
        target=GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            
        }
        Collider[] hits=Physics.OverlapSphere(attackpoint.position, 1.5f, player);


        foreach (Collider hit in hits)
        {
            if (canAttack)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().TakeDamage(10f);
                StartCoroutine(Wait());

            }


        }
    }
    private IEnumerator Wait()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.5f);
        canAttack = true;

    }

}
