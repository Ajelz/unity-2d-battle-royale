using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userHealthbar : MonoBehaviour
{
    OldPlayer myPlayer;
    [SerializeField] HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth = 0;
    bool isAlive;

    void Start()
    {
        isAlive = true;
        myPlayer = GetComponent <OldPlayer>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        Death();
        LifeStatus();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

    public bool LifeStatus() //Player is killed within this class, then sent information to OldPlayer, then retrieved in this function from OldPlayer to make sure Is actually dead, then passed to other scripts.
    {
        isAlive = myPlayer.isPlayerAlive();
        return isAlive;
    }

    void Death()
    {
        if (currentHealth <= 0)
        {
            myPlayer.setIsAlive(false);
        }
        else
        {
            myPlayer.setIsAlive(true);
        }
    }
}
