using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform playerAttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 2;

   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Block();
        }
    }


    void Attack()
    {
        //Detects enemies in the range of our attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(playerAttackPoint.position,attackRange,enemyLayers);

        //Damage
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Health>().Damage(attackDamage);
            enemy.GetComponent<EnemyAnimation>().hurtAnimation();
        }
    }

    void Block()
    {

    }

    void OnDrawGizmos()
    {
        if (playerAttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(playerAttackPoint.position, attackRange);
    }
}
