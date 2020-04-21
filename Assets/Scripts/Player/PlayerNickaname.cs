using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNickaname : MonoBehaviour
{
    public GameObject player;
    public Text PlayerNick;
    private PhotonView photonView;

    

    void Start()
    {
        
        photonView = GetComponent<PhotonView>();
        player.name = photonView.Owner.NickName;
        PlayerNick.text = photonView.Owner.NickName;
    }

    
    void Update()
    {
        
    }
}
