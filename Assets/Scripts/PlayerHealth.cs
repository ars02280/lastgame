using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueRectTransform;
    public float _maxValue;
    public GameObject GameUI;
    public GameObject GameOver;
    public Animator animator;
    void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }


    void Update()
    {

    }
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            GameOverP();
        }
        DrawHealthBar();
    }

    public void AddHealth(float amount)
    {
        value += amount;
        value = Mathf.Clamp(value,0,_maxValue);
        DrawHealthBar();
    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }
    public void GameOverP()
    {
        GameUI.SetActive(false);
        GameOver.SetActive(true);
        GameOver.GetComponent<Animator>().SetTrigger("show");
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        animator.SetTrigger("Die");

    }
}
