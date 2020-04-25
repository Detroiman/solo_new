using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviourPun, IPunObservable
{
    public GameObject Cam;
    public Slider slider;
    public int Health;
    public int MaxHealth;

    void Start() {
        
        Debug.Log(Cam.name);
        slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();

    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(Health);

        }
        else if (stream.IsReading) {
            Health = (int)stream.ReceiveNext();

        }
    }
    public void TakeDamage(int amount) {
        Debug.Log(Health);
        if (photonView.IsMine) {
            photonView.RPC("Damage", RpcTarget.All, amount);
            SetHealth();

        }
    }

    void Update() {

       
        if (Health <= 0) {
            photonView.RPC("DoDeath", RpcTarget.All);
        }
        
        
    }


    [PunRPC]
    void Damage(int amount) {

        Health -= amount;
    }
    [PunRPC]
    void DoDeath() {
        gameObject.SetActive(false);
    }

    public void SetHealth() {
        slider.value = Health;   
    }

}
