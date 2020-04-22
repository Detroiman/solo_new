using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviourPun, IPunObservable
{

    public int Health;
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

   

    [PunRPC]
    void Damage(int amount) {

        Health -= amount;
    }



}
