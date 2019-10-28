using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHiddenGround : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //check, if gameobject has tag Player
        if (other.tag == "Player")
        {

            //delete hidden ground gameobject from the scene
            Destroy(this.gameObject);
        }
    }
}
