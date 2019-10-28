using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy: MonoBehaviour
{
    EnemyScrip enemy;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScrip>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            enemy.isAttacking = true;
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            enemy.isAttacking = false;
        }
    }
}
