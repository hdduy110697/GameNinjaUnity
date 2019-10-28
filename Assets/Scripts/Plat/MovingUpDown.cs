using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUpDown : MonoBehaviour
{
    public float speed = 0.05f, changeDirection = -1;
    Vector3 move;

    public PausedMenu paused;

    // Start is called before the first frame update
    void Start()
    {
        this.move = transform.position;
        paused = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PausedMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (paused.pause)
        {
            this.transform.position = this.transform.position;
        }
        if (paused.pause == false)
        {
            //tien toi vi tri moi
            move.y += speed;
            //set vi tri moi
            transform.position = move;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //tiep xuc voi 
        if (col.collider.CompareTag("Ground"))
        {
            speed *= changeDirection;
        }
    }
}
