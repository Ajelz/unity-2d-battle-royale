using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 0;
    [SerializeField] HealthBar healthBar;
    bool isAlive;

    Rigidbody2D myRigid;
    OldPlayer myPlayer;
    CapsuleCollider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        myPlayer = GetComponent <OldPlayer>();
        myRigid = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CapsuleCollider2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    private void OnCollisionEnter2D(Collision2D shot)
    {
        if (shot.gameObject.CompareTag("Bullet"))
        {
            print("ROBIN GOT SHOT");
            TakeDamage(5);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     TakeDamage(5);
        // }
        Death();
        LifeStatus();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

    public bool LifeStatus()
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
