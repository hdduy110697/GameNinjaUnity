using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    Rigidbody2D rb2d;
    Player player;
    // Start is called before the first frame update
    Vector2 moveDirection;
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        rb2d = GetComponent<Rigidbody2D>();
        moveDirection = (player.transform.position - transform.position).normalized * 20;
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y+3f);
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
        if (collision.gameObject.CompareTag("Player"))
        {
            player.Damage(1);
        }
    }
    void DestroySelf()
    {
        DestroyObject(this.gameObject);
    }
}
