using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
            health = 0;
        if (health <= 0)
        {
            Destroy(gameObject);
            healthBar.fillAmount = 0f;
        }
    }
}
