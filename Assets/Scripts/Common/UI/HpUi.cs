using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HpUi : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    Vector3 localScale;
    Vector3 localPosition;

    Vector3 StartScale;
    Vector3 StartPosition;

    float newScaleX;
    float newPosX;
    float hpDe;// mau giam

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        StartScale = transform.localScale;
        StartPosition = GameObject.FindWithTag("HpUI").transform.localPosition;
        if (PlayerPrefs.HasKey("heal"))
        {
            Scene activeScreen = SceneManager.GetActiveScene();
            if (activeScreen.buildIndex == 0)
            {
                player.heal = player.maxHeal;
            }
            else PlayerPrefs.GetFloat("heal");
        }
    }
    

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (player.heal <= 0)
        {
            KillSelf();
        }
        else
        {
            hpDe = (player.maxHeal - player.heal) / player.maxHeal;
            
            newScaleX = (StartScale.x) - (StartScale.x) * hpDe;
           
            newPosX = StartPosition.x - (StartScale.x - newScaleX) / 2;
            
            localScale = StartScale;
            localScale.x = newScaleX; /*Scale hien tai*/
            localPosition = StartPosition;
            localPosition.x = newPosX;
            transform.localScale = localScale;
            transform.localPosition = localPosition;

        }


    }
    private void KillSelf()
    {
        Destroy(this.gameObject);
    }
}
