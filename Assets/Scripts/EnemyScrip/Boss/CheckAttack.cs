using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttack : MonoBehaviour
{
    public Totem totem;
    // Start is called before the first frame update
    void Start()
    {
        totem = GameObject.FindGameObjectWithTag("Boss").GetComponent<Totem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            totem.isAttacking = true;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            totem.isAttacking = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            totem.isAttacking = false;
        }
    }
}
