using Photon.Pun;
using Photon.Realtime;
using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField RoomName;
    public InputField RoomSize;
    public GameObject RoomSettings;
    public InputField JoinRoomName;
    public GameObject JoinSettings;
    public Text LogText;
    bool text = false;
    bool isConnecting = false;
    bool search = false;
    string roomname;
    string GameVersion = "1";
    private void Start()
    {
        if (string.IsNullOrEmpty(PhotonNetwork.NickName))
        {
            PhotonNetwork.NickName = "Player" + UnityEngine.Random.Range(1000, 9999).ToString();

        }
        Log("Player`s name is set to " + PhotonNetwork.NickName);
        PhotonNetwork.GameVersion = GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    void Log(string message)
    {
        Debug.Log(message);
        LogText.text += "\n";
        LogText.text += message;
    }
    public void Createroom()
    {
        
        if (isConnecting && !search) {
            int sizeRoom = 5;
            try
            {
                sizeRoom = Int32.Parse(RoomSize.text);
            }
            catch {
                sizeRoom = 5;
            }
            if (sizeRoom > 8) {
                sizeRoom = 8;
            }
            if (string.IsNullOrEmpty(RoomName.text)) {

                RoomName.text = "Room" + UnityEngine.Random.Range(1000, 9999).ToString();
            }
            RoomSize.text = sizeRoom.ToString();
            PhotonNetwork.CreateRoom(RoomName.text, new RoomOptions { MaxPlayers = (byte)(sizeRoom)});
            
        }
    }
    public void Joinroom() {
       
        if (isConnecting & !search)
        {
            
            if (string.IsNullOrEmpty(JoinRoomName.text))
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                roomname = JoinRoomName.text;
                PhotonNetwork.JoinRoom(roomname, null);
            }
        }
    
    }
    public override void OnConnectedToMaster()
    {
        isConnecting = true;
        Log("Connected to Master");
        
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Log($"Disconnected due to: {cause}");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        search = false;
        if (!text)
        {
            JoinRoomName.text = "No such room: " + roomname;
            text = true;
        }
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Log("No clients are waiting for an opponent, creating new room");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 5 });
    }
    public override void OnJoinedRoom()
    {
        search = true;
        Log("Client succefully joined a room");
       
        Log("Room created with name: " + PhotonNetwork.CurrentRoom.Name + " and max players: " + PhotonNetwork.CurrentRoom.MaxPlayers);
        
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        Log("Player in search: " + playerCount.ToString());
        if (playerCount >= 2)
        {
            Log("Match is ready");
        }
        else
        {
            Log("Client is waiting for an opponent");
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Log(PhotonNetwork.CurrentRoom.PlayerCount.ToString());
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            Log("Max players!");
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            Debug.Log("Game");
            PhotonNetwork.LoadLevel("Game");
            Log(PhotonNetwork.NickName);
        }
    }

    public void OpenRoomSettings() {
        if (RoomSettings.activeSelf)
        {
            RoomSettings.SetActive(false);
        }
        else {
            if (JoinSettings.activeSelf)
            {
                Leave();
                JoinSettings.SetActive(false);
            }
            RoomSettings.SetActive(true);
        }
    }
    public void OpenJoinSettings()
    {
        if (JoinSettings.activeSelf)
        {
            JoinSettings.SetActive(false);
        }
        else
        {
            if (RoomSettings.activeSelf) {
                Leave();
                RoomSettings.SetActive(false) ;
            }
            JoinSettings.SetActive(true);
        }
    }

    public void Leave()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
            search = false;
        }
    }

    public void Disconnect() {
        PhotonNetwork.Disconnect();
    
    }
}
