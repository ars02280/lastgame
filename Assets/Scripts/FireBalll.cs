using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBalll : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float damage = 10;

    void Start()
    {
        Invoke("DestroyFireBall", lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyFireBall();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
        
    }
    private void DestroyFireBall()
    {
        Destroy(gameObject);
    }

    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        } 
    }
    
}
