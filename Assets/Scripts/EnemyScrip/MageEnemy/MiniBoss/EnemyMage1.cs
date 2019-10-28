using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMage1 : MonoBehaviour
{
    public float maxHealth = 15f;
    public float health ;
    private Material Red;
    private Material Default;
    private Material SuperMage;
    private UnityEngine.Object explosionRef;
    float moveSpeed = 3f;
    private bool faceright = false;
    float dirX;
    //start posision
    float startPosition;
    Vector3 localScale;

    float fireRate;
    float nextFire;

    public static bool isAttacking = false;
    Animator anim;

    Rigidbody2D r2;
    SpriteRenderer sr;
    // Start is called before the first frame update
    //bulletRef
    UnityEngine.Object bulletRef;

    void Start()
    {
        health = maxHealth;
        
        fireRate = 1.5f;
        nextFire = Time.time;

        bulletRef = Resources.Load("FireBall");
        anim = GetComponent<Animator>();
        startPosition = transform.position.x;
        localScale = transform.localScale;
        r2 = GetComponent<Rigidbody2D>();
        explosionRef = Resources.Load("Explosion");
        sr = GetComponent<SpriteRenderer>();
        Red = Resources.Load("RedEnemy", typeof(Material)) as Material;
        SuperMage = Resources.Load("SuperMage", typeof(Material)) as Material;
        Default = sr.material;
        dirX = -1f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x < startPosition - 1.6f)
        {
            dirX = 1f;
        }
        if (transform.position.x > startPosition + 1.6f)
        {
            dirX = -1f;
        }
        if (isAttacking)
        {
            anim.SetBool("isAttacking", true);

        }         
        else
            anim.SetBool("isAttacking", false);

    }

    private void CheckIfTimeToFire()
    {
        
            if (!faceright)
            {
                if (Time.time > nextFire)
                {
                    GameObject bullet = (GameObject)Instantiate(bulletRef);
                    bullet.transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y + .2f, -1);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
                    nextFire = Time.time + fireRate;

                }

            }
            if (faceright)
            {
                if (Time.time > nextFire)
                {
                    GameObject bullet = (GameObject)Instantiate(bulletRef);
                    bullet.transform.position = new Vector3(transform.position.x + 0.4f * (-1), transform.position.y + .2f, -1);
                    Vector3 ScaleKunai;
                    ScaleKunai = bullet.transform.localScale;
                    ScaleKunai.x *= -1;
                    bullet.transform.localScale = ScaleKunai;
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
                    nextFire = Time.time + fireRate;

                }

            }
        
        
    }

    private void FixedUpdate()
    {
        if (!isAttacking)
            r2.velocity = new Vector2(dirX * moveSpeed, r2.velocity.y);
        else
        {
            r2.velocity = Vector2.zero;
            CheckIfTimeToFire();
        }
        if (health <= 0)
        {
            KillSelf();
        }
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
        if (((faceright) && (localScale.x < 0) || ((!faceright) && (localScale.x > 0))))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
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
    public void Damage(int damage)
    {
        //luong mau mat = damage
        health -= damage;
        sr.material = Red;
        if (health > 15)
        {
            Invoke("ResetMaterial", .06f);
        }
        else// khi < 15 mau hoa' supper :)))
        {
            Invoke("SuperMaterial", .06f);
        }
    }
    void SuperMaterial()
    {
        sr.material = SuperMage;
    }
}
