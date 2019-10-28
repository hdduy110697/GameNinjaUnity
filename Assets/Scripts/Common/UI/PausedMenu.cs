using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public bool pause = false;
    public GameObject pauseUI;

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //kiem tra khi nhan nut escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }

        //pause
        if (pause)
        {
            pauseUI.SetActive(true);
            //set time cho game
            Time.timeScale = 0;
        }
        //unpause
        if(pause == false)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void resume()
    {
        pause = false;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //khi dang build quit ko hoat dong
    public void quit()
    {
        Application.Quit();
    }
    //can sua
    void FixUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (player == null)
        {
            pause = !pause;
            pauseUI.SetActive(true);
        }
    }
}
