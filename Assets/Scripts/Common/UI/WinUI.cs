using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    public bool win = false;
    public GameObject winUI;

    public EnemyMage enemyMage;
    // Start is called before the first frame update
    void Start()
    {
        enemyMage = GameObject.FindGameObjectWithTag("EnemyMage").GetComponent<EnemyMage>();
        winUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyMage.health <= 0)
        {
            win = true;
        }
        if (win)
        {
            winUI.SetActive(true);
        }
        if (win == false)
        {
            winUI.SetActive(false);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }

    public void restartLV2()
    {
        SceneManager.LoadScene(1);
    }
    
}
