using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{
    public Rigidbody2D r2;
    public float timeDelay = 1;


    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D col)
    {
        //tiep xuc voi object co tag la Player
        if (col.collider.CompareTag("Player"))
        {
            StartCoroutine(fall());
        }
    }

    IEnumerator fall()
    {
        //doi time Delay
        yield return new WaitForSeconds(timeDelay);
        //doi r2 thanh Dynamic (set mac dinh la static)
        r2.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }
}
