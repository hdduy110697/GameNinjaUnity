using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTotemBoss : MonoBehaviour
{
    public Player player;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("DestroySelf", 1f);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("LeftRight") ||
            collision.gameObject.CompareTag("UpDown") ||
            collision.gameObject.CompareTag("DeadEnd")
            )
        {
            DestroySelf();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            DestroySelf();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.Damage(1);

        }
    }
    void DestroySelf()
    {
        DestroyObject(this.gameObject);
    }
}
