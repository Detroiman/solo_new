using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviourPun, IPunObservable
{
    public Slider slider;
    public int Health;
    public int MaxHealth;
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
        }
    }

    void Update() {

        if (photonView.IsMine) {
            if (Health <= 0) {
                photonView.RPC("DoDeath", RpcTarget.All);
            }
            SetHealth();
        }
        
    }


    [PunRPC]
    void Damage(int amount) {

        Health -= amount;
    }

    void DoDeath() {
        gameObject.SetActive(false);
    }

    public void SetHealth() {
        slider.value = Health;   
    }

}
