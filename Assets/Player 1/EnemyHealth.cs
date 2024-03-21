using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   [SerializeField] float health;
    public void TakeDamage(float damage)
    {
        if(health > 0)
        {
            health -= damage;
            if (health <= 0) EnemyDeath();
            Debug.Log("Hit");
        }
    }
    void EnemyDeath()
    {
        Debug.Log("Death");
    }
}
