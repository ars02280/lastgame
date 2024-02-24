using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBalll : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    void Start()
    {
        Invoke("DestroyFireBall", lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        DestroyFireBall();
    }
    private void DestroyFireBall()
    {
        Destroy(gameObject);
    }
}
