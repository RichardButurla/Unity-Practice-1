using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MAX_HEALTH = 10;
    private int health = 10;

    
    // Update is called once per frame
    void Update()
    {
       
    }

    void Start()
    {
        health = MAX_HEALTH;
    }

    public void Damage(int t_amount)
    {
        if(t_amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= t_amount;

        if (health <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Debug.Log("this object has died!");
        Destroy(gameObject);
    }
}
