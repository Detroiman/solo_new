using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    [SerializeField] private GameObject playerPrefab = null;
    

    private void Start()
    {
        
        var player = PhotonNetwork.Instantiate(playerPrefab.name,new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        player.name = PhotonNetwork.NickName;
    }

}
