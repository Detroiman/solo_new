using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviourPun
{
    private int damage;
    private float speed;
    private float distance;
    private float time;

    private void Start()
    {
        time = distance / speed;
        
        DestroyBullet(time);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colided!!!");
        if (collision.tag == "Player")
        {
            PlayerData pd = collision.GetComponent<PlayerData>();
            pd.TakeDamage(damage);
        }
        DestroyBullet(0f);
    }
    void DestroyBullet(float interval) {
        Destroy(this, interval);
    }
    public void setBullet(int Damage, float Speed, float Distance)
    {
        damage = Damage;
        speed = Speed;
        distance = Distance;

    }
}
