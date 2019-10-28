using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Totem : MonoBehaviour
{
    public Player player;
    public GateToLvl2 gate;
    
    public int maxHealth = 20, health;
    private UnityEngine.Object explosionRef;
    public bool isAttacking = false;
    Animator anim;
    Rigidbody2D r2;
    Object bulletRef1;
    Object bulletRef2;

    float nextFire;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        r2 = GetComponent<Rigidbody2D>();
        bulletRef1 = Resources.Load("BulletTotem");
        bulletRef2 = Resources.Load("BulletTotem2");
        health = maxHealth;
        nextFire = Time.time;
        gate = GameObject.FindGameObjectWithTag("Gate").GetComponent<GateToLvl2>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Invoke("ChangeLV", 5f);
            //gate.transform.position = new Vector2(167.37f, 4.6f);
            KillSelf();
            
        }
        if (isAttacking)
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttacking", false);
    }
    
    void FixedUpdate() {
        
        if (isAttacking)
        {
            {
                /*if (Time.time > nextFire)
                {
                    GameObject bullet = (GameObject)Instantiate(bulletRef2);
                    bullet.transform.position = new Vector3(r2.transform.position.x - 0.4f, r2.transform.position.y + 1.5f, -1);
                    //position 160.3143, 8.050981,-1
                    
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(posX - (r2.transform.position.x - 0.4f), posY - (r2.transform.position.y + 1.5f));
                    
                    nextFire = Time.time + 2f;
                }*/
            }
            if(health <= maxHealth/2)
            {

                if (Time.time > nextFire)
                {
                    GameObject bullet = (GameObject)Instantiate(bulletRef1);
                    bullet.transform.position = new Vector3(r2.transform.position.x - 0.4f, r2.transform.position.y - .2f, -1);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0);
                                                         
                    nextFire = Time.time + 0.3f;

                }
                /*if (Time.time > nextFire)
                {
                    GameObject bullet = (GameObject)Instantiate(bulletRef2);
                    bullet.transform.position = new Vector3(r2.transform.position.x - 0.4f, r2.transform.position.y + 1.5f, -1);
                    //position 160.3143, 8.050981,-1

                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(posX - (r2.transform.position.x - 0.4f), posY - (r2.transform.position.y + 1.5f));

                    nextFire = Time.time + 2f;
                }*/
            }
            if(health > maxHealth/2)
            {
                if (Time.time > nextFire)
                {
                    GameObject bullet = (GameObject)Instantiate(bulletRef1);
                    bullet.transform.position = new Vector3(r2.transform.position.x - 0.4f, r2.transform.position.y - .2f, -1);
                    bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-8, -1);
                    nextFire = Time.time + 0.75f;
                }
                
            }
        }
    }
   
    private void KillSelf()
    {
        Destroy(this.gameObject);
        
    }

    

    public void Damage(int damage)
    {
        //luong mau mat = damage
        health -= damage;
    }

    public void ChangeLV()
    {
        SceneManager.LoadScene("LV2");
    }

    
}
