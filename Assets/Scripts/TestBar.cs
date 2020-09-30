using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    [SerializeField] HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.setHealth(currentHealth);
    }
}
