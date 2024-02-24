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

    // Start is called before the first frame update
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
        
    }

    private void NoticedPlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _IsPlayerNoticed = false;

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
    }

    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance == 0)
            PickNewPatrolPoint();
    }

    private void PickNewPatrolPoint()
    {   
    _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }   
  
   

}
