using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        //check, if gameobject has tag player
        if (other.tag == "Player")
        {
           
            
            //delete coin gameobject from the scene
            Destroy(this.gameObject);
        }
    }
}
