using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    private NavMeshAgent _navMeshAgent;
    public PlayerController player;
    private bool _IsPlayerNoticed;
    public float viewAngle;
    public float damage = 30;
    private PlayerHealth _playerHealth;
    public Animator animator;
    public float attackDistance = 1;
    public Transform playerTransform;


    void Start()
    {
        InitComponentsLinks();
        PickNewPatrolPoint();
    }

    // Update is called once per frame
    void Update()
    {
        NoticedPlayerUpdate();
        if (_IsPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
        else
        {
            PatrolUpdate();
        }
        AttackUpdate();
    }

    

    private void AttackUpdate()
    {
        if (_IsPlayerNoticed == true && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {

            animator.SetTrigger("attack");

        }
    }
    

    public void AttackDamage()
    {
        if (_IsPlayerNoticed == true && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance + attackDistance)
        {
            _playerHealth.DealDamage(damage);
        }
    }




    private void NoticedPlayerUpdate()
    {
        
        _IsPlayerNoticed = false;
        if ( _playerHealth.value <= 0 )return ;
        var direction = player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _IsPlayerNoticed = true;
                }

            }

        }
    }
    private void InitComponentsLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            PickNewPatrolPoint();
        }
    }

    private void PickNewPatrolPoint()
    {   
    _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }   
  
   

}
