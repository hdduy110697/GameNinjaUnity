using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeType1 : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();   
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("GroundCheck"))
        {
            player.Damage(1);
            
        }
    }
}
