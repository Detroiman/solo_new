using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviourPunCallbacks
{
    public GameObject Pause;
	public GameObject Exit;
	public GameObject VoicePause;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
	public void buttonPause()
	{
		deactivatrExit();
		///PhotonNetwork.LeaveRoom();
	}
	public void buttonExit()
	{
		Application.LoadLevel("Main Menu");
	}
	public void buttonVoicePause()
	{
	}
	public void deactivatrExit()
	{
	
		if (Exit.activeSelf)
		{
			Exit.SetActive(false);
			VoicePause.SetActive(false);
		}
		else
		{
			Exit.SetActive(true);
			VoicePause.SetActive(true);
		}
		
	}
	public override void OnLeftRoom()
	{
		SceneManager.LoadScene(1);
	}
}
