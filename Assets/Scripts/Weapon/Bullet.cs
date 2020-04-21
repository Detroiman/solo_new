using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviourPun
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colided!!!");
        if (collision.collider.tag == "Player")
        {
            PlayerData pd = collision.gameObject.GetComponent<PlayerData>();
            Debug.Log(this.name);
            

        }
    }

}
