using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiScript : MonoBehaviour
{
    public EnemyMage enemyMage;
    public EnemyMage1 enemyMage1;
    public Totem totem;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // tu dong goi ham DestroySelf sau 1 khoan time nhat dinh
        Invoke("DestroySelf", .4f);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("LeftRight") ||
            collision.gameObject.CompareTag("UpDown")
            )
        {
            DestroySelf();
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            DestroySelf();
            totem = GameObject.FindGameObjectWithTag("Boss").GetComponent<Totem>();
            totem.Damage(1);

        }
        if (collision.gameObject.CompareTag("EnemyMage"))
        {
            DestroySelf();
            enemyMage = GameObject.FindGameObjectWithTag("EnemyMage").GetComponent<EnemyMage>();
            enemyMage.Damage(1);

        }
        if (collision.gameObject.CompareTag("EnemyMage1"))
        {
            DestroySelf();
            enemyMage1 = GameObject.FindGameObjectWithTag("EnemyMage1").GetComponent<EnemyMage1>();
            enemyMage1.Damage(1);

        }
    }
    void DestroySelf()
    {
        DestroyObject(this.gameObject);
    }
}
