using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    public float explotionSize = 10;
    public float explotionSpeed = 50;
    public float damage = 50;
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * explotionSpeed;
        if (transform.localScale.x > explotionSize)
        {
            Destroy(gameObject);        
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.DealDamage(damage);
        }

       var enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
            Debug.Log(3);
        }
        else
        {
            Debug.Log(4);
                
        }
        
    }
}
