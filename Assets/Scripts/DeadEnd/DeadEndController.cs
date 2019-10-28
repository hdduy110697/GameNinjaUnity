using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//we need this library if we use scene manager
using UnityEngine.SceneManagement;

public class DeadEndController : MonoBehaviour
{
    //will be started if 2D collider went into the trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        //check if collided gameobject has tag Player
        if (other.tag == "Player")
        {
            //get the loaded scene name and load scene that has this name (reload)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
