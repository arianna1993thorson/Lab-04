using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundLayer, playerLayer;

    public Vector3 walkPoint;
    bool setWalkPoint;
    public float rangeOfWalkPoint;

    public float attackTime;
    bool hasAttacked;
    public GameObject bullet;
    public GameObject bulletPos;
    public float lineOfSight, rangeOfAttack;
    public float playerSightRange, playerAttackRange;

    // Start is called before the first frame update
    private void Awake()
    {
        agent.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerSightRange = Physics.CheckSphere(transform.position, lineOfSight, playerLayer);
        playerAttackRange = Physics.CheckSphere(transform.position, lineOfSight, playerLayer);

        if (!playerSightRange && !playerAttackRange) patrol();
        if (playerSightRange && !playerAttackRange) chasePlayer();
        if (playerSightRange && !playerAttackRange) attackPlayer();
    }

    private void chasePlayer()
    {

    }

    private void attackPlayer()
    {

    }

    private void patrol()
    {
        if (setWalkPoint) searchWalkPoint();
        void searchWalkPoint()
        {
            float randomX = Random.Range(-rangeOfWalkPoint, rangeOfWalkPoint);
            float randomZ = Random.Range(-rangeOfWalkPoint, rangeOfWalkPoint);
            walkPoint = new Vector3(randomX, transform.position.x, randomZ);
            if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayer))
            {
                setWalkPoint = true;
            }
        }

        if (setWalkPoint)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 walkPointDistance = transform.position = walkPoint;
        if(walkPointDistance.magnitude < 1f)
        {
            setWalkPoint = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, lineOfSight);
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, rangeOfAttack);
    }
}
