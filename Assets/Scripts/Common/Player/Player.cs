using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    //sound
    public AudioClip coinAudio, deadAudio, jumpAudio, kunaiAudio;
    public AudioSource ad;
    //end sound
    // explotion dead
    private UnityEngine.Object explosionRef;
    

    public float maxHeal = 10;
    public float heal;
    public int coin;
    
    public float speed = 50f, maxSpeed = 3, jumpPow = 220f, maxJump = 4;
    public bool grounded = true, faceright = true, doubleJump = false;
    
    //bulletRef
    Object bulletRef;

    public Rigidbody2D r2;
    public Animator anim;

    public GameObject TextObject;
    Text textComponent;

    public GameObject PressE;
    Text press;
    
    // Start is called before the first frame update
    void Start()
    {
        // sound

        coinAudio = Resources.Load<AudioClip>("CoinSound");
        deadAudio = Resources.Load<AudioClip>("DeadSound");
        jumpAudio = Resources.Load<AudioClip>("JumpSound");
        kunaiAudio = Resources.Load<AudioClip>("KunaiSound");
        ad = this.GetComponent<AudioSource>();
        //end sound

        heal = maxHeal;

        explosionRef = Resources.Load("Explosion");
        // get bullet from resources
        bulletRef = Resources.Load("Kunai");
        // hien score
        textComponent = TextObject.GetComponent<Text>();
        press = PressE.GetComponent<Text>();
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        textComponent.text = ("" + PlayerPrefs.GetInt("coin"));
        if (PlayerPrefs.HasKey("coin"))
        {
            Scene activeScreen = SceneManager.GetActiveScene();
            if (activeScreen.buildIndex == 0)
            {
                PlayerPrefs.DeleteKey("coin");
                coin = 0;
            }
            else PlayerPrefs.GetInt("coin");
        }
        
    }

    //kiem tra trang thai
    // Update is called once per frame
    void Update()
    {
        //set vi tri cho player
        anim.SetBool("Grounded", grounded);
        //set toc do, tra ve gia tri duong khong tra gia tri am
        /*anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));*/
        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
        }
        //lam player nhay
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                
                grounded = false;
                doubleJump = true;
                //up chi anh huong toi gia tri y khong anh huong gia tri x
                //bam space de nhay
                r2.AddForce(Vector2.up * jumpPow);
                JumpSound();
            }

            //double jump
            else
            {
                if (doubleJump)
                {
                    
                    doubleJump = false;
                    //0 de reset lai y de tranh cong don lai voi lan 1
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    //0.7 de giam kha nang nhay lai
                    r2.AddForce(Vector2.up * jumpPow * 0.7f);
                    JumpSound();
                }

            }
        }
        
    }

    //kiem tra tac dong toi player
    //lien quan den vat ly
    void FixedUpdate()
    {
        if (heal <= 0)
        {
            anim.Play("DeadAnimation");
            DeadSound();
            Invoke("KillSelf", 1.2f);
            

        }
        if (heal > 0)
        {
            float h = Input.GetAxis("Horizontal");
            r2.AddForce((Vector2.right) * speed * h);

            //qua phai
            //neu toc do > toc do toi da
            if (r2.velocity.x > maxSpeed)
            {
                //tao 1 vector moi voi x = maxspeed(x = 3) va y (y = 0)
                r2.velocity = new Vector2(maxSpeed, r2.velocity.y);
            }

            //qua trai
            //neu toc do < toc do toi da
            if (r2.velocity.x < -maxSpeed)
            {
                //tao 1 vector moi voi x = -maxspeed(x = 3) va y (y = 0)
                r2.velocity = new Vector2(-maxSpeed, r2.velocity.y);
            }

            if (r2.velocity.y > maxJump)
            {

                r2.velocity = new Vector2(r2.velocity.x, maxJump);
            }
            if (r2.velocity.y < -maxJump)
            {

                r2.velocity = new Vector2(r2.velocity.x, -maxJump);
            }

            //kiem tra huong mat
            if (h > 0 && !faceright)
            {
                Flip();
            }

            if (h < 0 && faceright)
            {
                Flip();
            }

            //tao ma sat
            if (grounded)
            {
                r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
            }
            
        }
        // animator shoot
        if (Input.GetKeyDown(KeyCode.Z) && heal > 0)
        {
            anim.Play("ShootAnimation");
            KunaiSound();
            // CHECK FACE
            if (faceright)
            {
                GameObject bullet = (GameObject)Instantiate(bulletRef);
                bullet.transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y + .2f, -1);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(30, 0);

            }
            if (!faceright)
            {
                GameObject bullet = (GameObject)Instantiate(bulletRef);
                bullet.transform.position = new Vector3(transform.position.x + 0.4f * (-1), transform.position.y + .2f, -1);
                Vector3 ScaleKunai;
                ScaleKunai = bullet.transform.localScale;
                ScaleKunai.y *= -1;
                bullet.transform.localScale = ScaleKunai;
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-30, 0);
                
            }
        }
        
        
    }

    //lat hinh anh player
    void Flip()
    {
        //set lai gia tri true false
        faceright = !faceright;

        Vector3 Scale;
        //set bien Scale 
        Scale = transform.localScale;
        //lat hinh anh, thay doi gia tri Scale
        Scale.x *= -1;
        //set gia tri de lat hinh anh
        transform.localScale = Scale;
    }
    // get coin
    void OnTriggerEnter2D(Collider2D other)
    {
        //check, if gameobject has tag Coin
        if (other.tag == "Coin")
        {
            
            //inc rement the coin counter variable
            coin++;
            
            //transform int variable into string variable and assign the result to the text in the Text component
            textComponent.text = coin.ToString();
            //delete coin gameobject from the scene
            Destroy(other.gameObject);
            CoinSound();
        }

        if (other.tag == "Gem")
        {
            
            //inc rement the coin counter variable
            coin += 10; 
            //transform int variable into string variable and assign the result to the text in the Text component
            textComponent.text = coin.ToString();
            //delete coin gameobject from the scene
            Destroy(other.gameObject);
            CoinSound();
        }
        if (other.tag == "Sword")
        {
            heal--;
        }
        if (other.CompareTag("Potion"))
        {
            //tang mau hien tai
            heal++;
            //delete potion tren scene
            Destroy(other.gameObject);
        }
        

        if (other.CompareTag("Gate"))
        {
            SavePoint();
            press.text = ("Press E to enter");
        }
        else press.text = ("");
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Gate"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                SavePoint();
                SceneManager.LoadScene(1);
            }
        }
    }



    
    
    private void KillSelf()
    {
        Destroy(this.gameObject);
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y + .2f, transform.position.z);
    }
    //khi chet load lai ban dau
    //khi chet load lai ban dau
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Damage(int damage)
    {
        //luong mau mat = damage
        heal -= damage;
    }

    public void Knockback(float knockPow, Vector2 knockDir)
    {
        float h = Input.GetAxis("Horizontal");
        //set lai van toc
        r2.velocity = new Vector2(0, 0);
        if (h > 0)
        {
            //add luc knockback
            r2.AddForce(new Vector2(knockDir.x * -100, knockDir.y * knockPow));
        }
        if (h < 0)
        {
            r2.AddForce(new Vector2(knockDir.x * 100, knockDir.y * knockPow));
        }
    }
    void SavePoint()
    {
        PlayerPrefs.SetInt("coin", coin);
    }

    // jump sound
    public void JumpSound()
    {
        //play sound coin
        ad.clip = jumpAudio;
        ad.PlayOneShot(jumpAudio, .1f);
        //end play sound Coin
    }
    public void KunaiSound()
    {
        //play sound Kunai
        ad.clip = kunaiAudio;
        ad.PlayOneShot(kunaiAudio, .4f);
        //end play sound Kunai
    }
    public void CoinSound()
    {
        //play sound coin
        ad.clip = coinAudio;
        ad.PlayOneShot(coinAudio, 1f);
        //end play sound Coin
    }
    public void DeadSound()
    {
        //play sound dead
        ad.clip = deadAudio;
        ad.PlayOneShot(deadAudio, .2f);
        //end play sound dead
    }
}
