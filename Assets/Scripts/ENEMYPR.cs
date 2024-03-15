using UnityEngine;

public class ENEMYPR : MonoBehaviour
{
    public float maxHealth = 30;
    float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    //При столкновении с другим объектом
    private void OnCollisionEnter(Collision collision)
    {
        //Если скорость столкновения больше 10
        if (collision.relativeVelocity.magnitude > 10)
        {
            //Вызываем метод TakeDamage и передаем в него значение скорости столкновения
            TakeDamage(collision.relativeVelocity.magnitude);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}