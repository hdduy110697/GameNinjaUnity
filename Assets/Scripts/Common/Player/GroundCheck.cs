using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        //lay cac thuoc tinh tu class bo Player
        player = gameObject.GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("PlatUpDown") || collision.CompareTag("UpDown") 
            || collision.CompareTag("LeftRight") || collision.CompareTag("Water"))
        {
            player.grounded = true;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("PlatUpDown") || collision.CompareTag("UpDown") 
            || collision.CompareTag("LeftRight") || collision.CompareTag("Water"))
        {
            player.grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.grounded = false;
    }
}
