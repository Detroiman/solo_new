using Photon.Pun;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviourPun
{
    public float x;
    public float y;  
    public Text PlayerNick;
    public float cd_ability_leap = 8f;
    public float leap = 30f;
    public Rigidbody2D rb;
    public GameObject Weapon;
    public float speedt = 100f;
    public float jump_force = 25f;
    public int hp = 100;
    public float move;
    public CONTROLLPAD joystick;
    bool jump_const = true;
    bool facinRight = true;
    float deltax;
    float deltay;
    float leapx = 0f;
    float cd_leap;
    float time = 0f;
    Vector2 xy;

    void Start()
    {
        this.name = photonView.Owner.NickName;
        cd_leap = cd_ability_leap;
        rb.position = new Vector3(0f, 0f, 0f);
    }

    void FixedUpdate()
    {
        deltax = joystick.Horizontal();
        deltay = joystick.Vertical();
        time = Time.deltaTime; 
        cd_leap += time;      
        if (photonView.IsMine) {
            Takeinput();
        }


    }
    
    void Takeinput() {   
        if ((Mathf.Abs(deltax)) > (Mathf.Abs(deltay)))
        {
            if (deltax > 0)
            {
                if (!facinRight)
                    Flip();
                right(deltax);

            }
            else
            {
                if (facinRight)
                    Flip();
                left(deltax);

            }
        }
        else
        {
            if (deltay > 0)
            {
                if (jump_const){ 
                    jump(true);
                    
                }
            }
            else
            {
                if (!jump_const)
                {
                    jump(false);
                    
                }
            }
        }
            
    }
       
    void right(float m)
    {
        if (m > speedt)
            m = speedt;
        rb.velocity = new Vector2(m * 0.4f, rb.velocity.y);
    }

    void left(float m)
    {
     
        if (Mathf.Abs(m) > speedt)
            m = -speedt;
        rb.velocity = new Vector2(m * 0.4f, rb.velocity.y);
    }

    void Flip()
    {
        ///PlayerNick.transform.Rotate(0f, 180, 0f);
        facinRight = !facinRight;
        rb.transform.Rotate(0f, 180f, 0f);


    }

    public void Shoot()
    {
       
        Weapon.GetComponent<Weapon>().Shoot();
           
    }

    void jump(bool f)
    {
        float fm = -0.9f;
        if (f)
            fm = 0.9f;
        rb.AddForce(transform.up * (jump_force * fm), ForceMode2D.Impulse);
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Ground") { jump_const = true; }
        
    }
    void OnTriggerExit2D(Collider2D hitInfo) {
        if (hitInfo.tag == "Ground") { jump_const = false; }

    }
    public void ability_leap() 
    {
       
        if (cd_leap >= cd_ability_leap)
        {
            Debug.Log("Leap");
            leapx = facinRight ? leap : leap * (-1);
            rb.AddForce(transform.right * leapx, ForceMode2D.Impulse);
            cd_leap = 0f;
        }
        
      
    }
}

