using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpad : MonoBehaviour
{
    
    public float bounciness; //Коэффициент прыгучести (в сколько раз выше батут подкинет объект, в сравнении с стартовой высотой)

 
    void OnTriggerEnter2D(Collider2D other)
    {
        
        other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>().velocity.x, other.GetComponent<Rigidbody2D>().velocity.y * -1 * bounciness);
            
        
    }
}
