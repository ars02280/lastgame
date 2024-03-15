using UnityEngine;

public class ENEMYPR : MonoBehaviour
{
    public float maxHealth = 30;
    float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    //��� ������������ � ������ ��������
    private void OnCollisionEnter(Collision collision)
    {
        //���� �������� ������������ ������ 10
        if (collision.relativeVelocity.magnitude > 10)
        {
            //�������� ����� TakeDamage � �������� � ���� �������� �������� ������������
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