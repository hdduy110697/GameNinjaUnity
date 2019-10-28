using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{
    public Player player;
    
    public int highScore = 0;
    public int score;
    
    public Text scoreText;
    public Text highText;
    public Text inputText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        score = player.coin;
        highText.text = ("High Score: " + PlayerPrefs.GetInt("highScore"));
        highScore = PlayerPrefs.GetInt("highScore", 0);

        if (PlayerPrefs.HasKey("coin"))
        {
            Scene activeScreen = SceneManager.GetActiveScene();
            if (activeScreen.buildIndex == 0)
            {
                PlayerPrefs.DeleteKey("coin");
                score = 0;
            }
            else
                score = PlayerPrefs.GetInt("coin");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
