using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //check, if gameobject has tag Player
        if (other.tag == "Player")
        {
            
            //delete potion gameobject from the scene
            Destroy(this.gameObject);
        }
    }
}
