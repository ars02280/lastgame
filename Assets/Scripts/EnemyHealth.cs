using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator animator;
    void Start()
    {
        
    }
    

    void Update()
    {
        
    }
    public void DealDamageE(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            Death();
        }
        else
        {
            animator.SetTrigger("Hit");
        }
    }

    private void Death()
    {
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        animator.SetTrigger("Death");
    }
}
