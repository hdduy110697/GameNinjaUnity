using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    public bool death = false;
    public GameObject deathUI;

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        deathUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.heal <= 0)
        {
            death = true;
        }
        if (death)
        {
            deathUI.SetActive(true);
        }
        if(death == false)
        {
            deathUI.SetActive(false);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
