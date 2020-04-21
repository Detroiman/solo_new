using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsParam : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
	public void buttonBack()
	{
		Application.LoadLevel("Main Menu");
	}
	public void buttonInformation()
	{
	}
	public void buttonVoice()
	{
	}

	public void buttonAccount()
	{
		Application.LoadLevel("UserSettings");
	}
}
