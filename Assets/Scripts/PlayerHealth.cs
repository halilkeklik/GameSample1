using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private GameManager gameManager;

    private bool isDead;

    void Start()
    {
        health = maxHealth;
    }
    
    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (health <= 0 && !isDead)
        {
            isDead = true;
        }
    }
}
