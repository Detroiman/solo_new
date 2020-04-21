using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
	public GameObject Play;
	public GameObject Tutor;
	public GameObject Settings;
	public GameObject Exit;
	public GameObject Magazine;
    void Start()
    {
        
    }
    void Update()
    {
    }
	public void buttonPlaymenu()
	{
		Application.LoadLevel("Join room");
	}
	public void buttonTutormenu()
	{
		Application.LoadLevel("Tutor");
	}
	public void buttonSettingsmenu()
	{
		Application.LoadLevel("Settings");
	}
	public void buttonMagazine()
	{
		Application.LoadLevel("Magazine");
	}
	public void buttonExitmenu()
	{
		Application.Quit();
	}
}
