using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScrip : MonoBehaviour
{
    private int health = 10;
    private Material Red;
    private Material Default;
    private UnityEngine.Object explosionRef;
    float moveSpeed=2.5f;
    private bool faceright = false;
    float dirX;
    //start posision
    float startPosition;
    Vector3 localScale;

    public  bool isAttacking = false;
    Animator anim;

    Rigidbody2D r2;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        startPosition = transform.position.x;
        localScale = transform.localScale;
        r2 = GetComponent<Rigidbody2D>();
        explosionRef = Resources.Load("Explosion");
        sr = GetComponent<SpriteRenderer>();
        Red = Resources.Load("RedEnemy", typeof(Material)) as Material;
        Default = sr.material;
        dirX = -1f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x < startPosition-1.6f)
        {
            dirX = 1f;
        }
        if (transform.position.x > startPosition+ 1.6f)
        {
            dirX = -1f;
        }
        if (isAttacking)
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttacking", false);
    }
    private void FixedUpdate()
    {
        if (!isAttacking)
            r2.velocity = new Vector2(dirX * moveSpeed, r2.velocity.y);
        else
            r2.velocity = Vector2.zero;
    }
    private void LateUpdate()
    {
        CheckWhereToFace();
    }

    private void CheckWhereToFace()
    {
        if (dirX > 0)
        {
            faceright = true;
        }
        else if (dirX < 0)
            faceright = false;
        if (((faceright) && (localScale.x < 0) || ((!faceright) && (localScale.x > 0)))){
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Kunai"))
        {
            Destroy(collision.gameObject);
            health--;
            // hieu ung no
            
            //end
            sr.material = Red;
            if (health <= 0)
            {
                KillSelf();
            }
            else
            {
                // het .06 la resetMaterial
                Invoke("ResetMaterial", .06f);
            }
        }
    }

    void ResetMaterial()
    {
        sr.material = Default;
    }
    private void KillSelf()
    {
        Destroy(this.gameObject);
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y + .2f, transform.position.z);
    }

}
