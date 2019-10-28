using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMage1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            EnemyMage1.isAttacking = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            EnemyMage1.isAttacking = false;
        }
    }
}
