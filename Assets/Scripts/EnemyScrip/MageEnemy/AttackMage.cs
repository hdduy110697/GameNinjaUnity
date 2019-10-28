using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            EnemyMage.isAttacking = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            EnemyMage.isAttacking = false;
        }
    }
}
